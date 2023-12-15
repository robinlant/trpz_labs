import sqlite3
from datetime import datetime
import pandas as pd
from flask import g
from cur.config import path_to_db


class TransactionsHandler:
    def __init__(self, db_path=path_to_db):
        self.db_path = db_path

    def get_db(self):
        if 'db' not in g:
            g.db = sqlite3.connect(self.db_path)
        return g.db

    def execute_query(self, query, parameters=None):
        conn = self.get_db()
        cursor = conn.cursor()
        if parameters is None:
            parameters = ()
        cursor.execute(query, parameters)
        conn.commit()
        return cursor

    def add_transaction(self, amount, category, description, date=None, account_id=None):
        conn = self.get_db()
        cursor = conn.cursor()

        if date is None:
            date = datetime.now().strftime('%Y-%m-%d')

        cursor.execute('''
            INSERT INTO transactions (amount, category, description, date, account_id)
            VALUES (?, ?, ?, ?, ?)
        ''', (amount, category, description, date, account_id))

        if account_id:
            current_balance = cursor.execute('SELECT balance FROM accounts WHERE id = ?', (account_id,)).fetchone()[0]
            cursor.execute('UPDATE accounts SET balance = ? WHERE id = ?', (current_balance + amount, account_id))

        conn.commit()

    def add_recurring_transaction(self, amount, category, description, frequency, account_id):
        conn = self.get_db()
        cursor = conn.cursor()

        cursor.execute('''
            INSERT INTO recurring_transactions (amount, category, description, frequency, account_id)
            VALUES (?, ?, ?, ?, ?)
        ''', (amount, category, description, frequency, account_id))

        conn.commit()

    def process_recurring_transactions(self, account_id):
        conn = self.get_db()
        cursor = conn.cursor()

        cursor.execute('SELECT * FROM recurring_transactions WHERE account_id = ?', (account_id,))
        recurring_transactions = cursor.fetchall()

        for transaction in recurring_transactions:
            amount, category, description, frequency, _ = transaction
            today = datetime.now()
            last_transaction_date = self.get_last_transaction_date(category, account_id, cursor)

            if last_transaction_date is None or \
                    (frequency == 'monthly' and last_transaction_date.month != today.month) or \
                    (frequency == 'yearly' and last_transaction_date.year != today.year):
                self.add_transaction(amount, category, description, account_id=account_id)

    def get_last_transaction_date(self, category, account_id, cursor):
        cursor.execute('''
            SELECT MAX(date) FROM transactions
            WHERE category = ? AND account_id = ?
        ''', (category, account_id))
        return cursor.fetchone()[0]

    def get_all_transactions(self):
        conn = self.get_db()
        cursor = conn.cursor()

        cursor.execute('SELECT * FROM transactions')
        return cursor.fetchall()

    def import_from_excel(self, filename='financial_data.xlsx'):
        conn = self.get_db()
        cursor = conn.cursor()

        df = pd.read_excel(filename)
        for row in df.itertuples(index=False):
            if len(row) == 4:
                self.add_transaction(*row, cursor=cursor)
            elif len(row) == 5:
                self.add_transaction(*row[1:], cursor=cursor)

        conn.commit()