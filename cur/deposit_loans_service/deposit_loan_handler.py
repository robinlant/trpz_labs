import sqlite3
from flask import g
from datetime import datetime, timedelta
from cur.config import path_to_db


class DepositsLoansHandler:
    def __init__(self, db_path=path_to_db):
        self.db_path = db_path

    def get_connection(self):
        if 'db' not in g:
            g.db = sqlite3.connect(self.db_path)
        return g.db

    def execute_query(self, query, parameters=None):
        conn = self.get_connection()
        cursor = conn.cursor()
        if parameters is None:
            parameters = ()
        cursor.execute(query, parameters)
        conn.commit()
        return cursor

    def add_deposit(self, account_id, amount, interest_rate, term):
        conn = self.get_connection()
        cursor = conn.cursor()
        cursor.execute('''
            INSERT INTO deposits (account_id, amount, interest_rate, term)
            VALUES (?, ?, ?, ?)
        ''', (account_id, amount, interest_rate, term))
        deposit_id = cursor.lastrowid
        conn.commit()
        return deposit_id

    def add_loan(self, account_id, amount, interest_rate, term):
        conn = self.get_connection()
        cursor = conn.cursor()
        cursor.execute('''
            INSERT INTO loans (account_id, amount, interest_rate, term)
            VALUES (?, ?, ?, ?)
        ''', (account_id, amount, interest_rate, term))
        loan_id = cursor.lastrowid
        conn.commit()
        return loan_id

    def calculate_deposit_interest(self, deposit_id):
        deposit_info = self.execute_query('SELECT amount, interest_rate, term FROM deposits WHERE id = ?',
                                          (deposit_id,)).fetchone()
        amount, interest_rate, term = deposit_info
        interest_amount = amount * interest_rate * term / 12
        return interest_amount

    def calculate_loan_interest(self, loan_id):
        loan_info = self.execute_query('SELECT amount, interest_rate, term FROM loans WHERE id = ?',
                                       (loan_id,)).fetchone()
        amount, interest_rate, term = loan_info
        interest_amount = amount * interest_rate * term / 12
        return interest_amount

    def update_account_balance(self, account_id, new_balance):
        self.execute_query('''
            UPDATE accounts SET balance = ? WHERE id = ?
        ''', (new_balance, account_id))

    def display_loan_balance_by_month(self, loan_id):
        loan_info = self.execute_query('SELECT amount, interest_rate, term FROM loans WHERE id = ?', (loan_id,)).fetchone()
        amount, interest_rate, term = loan_info
        start_date = self.execute_query('SELECT date FROM transactions WHERE account_id = ? ORDER BY date ASC LIMIT 1',
                                       (loan_id,)).fetchone()[0]
        current_date = datetime.strptime(start_date, '%Y-%m-%d')
        remaining_balance = amount
        monthly_payment = amount * (interest_rate / 12) / (1 - (1 + interest_rate / 12) ** -term)
        print("Date\t\tRemaining Balance\t\tMonthly Payment\t\tPaid Principal\t\tPaid Interest")
        for _ in range(term):
            interest_payment = remaining_balance * interest_rate / 12
            principal_payment = monthly_payment - interest_payment
            remaining_balance -= principal_payment
            print(f"{current_date.strftime('%Y-%m-%d')}\t\t{remaining_balance:.2f}\t\t{monthly_payment:.2f}\t\t"
                  f"{principal_payment:.2f}\t\t{interest_payment:.2f}")
            current_date = current_date.replace(month=current_date.month + 1)
            self.execute_query('''
                UPDATE loans SET paid_amount = paid_amount + ?, paid_interest = paid_interest + ?
                WHERE id = ?
            ''', (principal_payment, interest_payment, loan_id))
        print("Loan balance calculation completed.")

    def display_deposit_balance_by_month(self, deposit_id):
        deposit_info = self.execute_query('SELECT amount, interest_rate, term FROM deposits WHERE id = ?', (deposit_id,)).fetchone()
        amount, interest_rate, term = deposit_info
        start_date = self.execute_query('SELECT date FROM transactions WHERE account_id = ? ORDER BY date ASC LIMIT 1',
                                       (deposit_id,)).fetchone()[0]
        current_date = datetime.strptime(start_date, '%Y-%m-%d')
        remaining_balance = amount
        print("Date\t\tRemaining Balance\t\tAccumulated Interest")
        for _ in range(term):
            interest_payment = remaining_balance * interest_rate / 12
            remaining_balance += interest_payment
            print(f"{current_date.strftime('%Y-%m-%d')}\t\t{remaining_balance:.2f}\t\t{interest_payment:.2f}")
            current_date += timedelta(days=30)
        print("Deposit balance calculation completed.")

    def process_monthly_transaction(self):
        today = datetime.now()
        deposits = self.execute_query('SELECT id, account_id, amount, interest_rate, term FROM deposits').fetchall()
        for deposit in deposits:
            deposit_id, account_id, amount, interest_rate, term = deposit
            start_date = self.execute_query(
                'SELECT date FROM transactions WHERE account_id = ? ORDER BY date ASC LIMIT 1',
                (account_id,)
            ).fetchone()[0]
            current_date = datetime.strptime(start_date, '%Y-%m-%d')
            if today.day == 1:
                interest_payment = amount * interest_rate / 12
                remaining_balance = amount + interest_payment
                self.execute_query('INSERT INTO transactions (amount, category, description, date, account_id) VALUES (?, ?, ?, ?, ?)',
                                   (-remaining_balance, 'withdrawal', 'Monthly deposit withdrawal', today.strftime('%Y-%m-%d'), account_id))
                self.update_account_balance(account_id, amount)
                current_date += timedelta(days=30)
        loans = self.execute_query('SELECT id, account_id, amount, interest_rate, term FROM loans').fetchall()
        for loan in loans:
            loan_id, account_id, amount, interest_rate, term = loan
            start_date = self.execute_query(
                'SELECT date FROM transactions WHERE account_id = ? ORDER BY date ASC LIMIT 1',
                (account_id,)
            ).fetchone()[0]
            current_date = datetime.strptime(start_date, '%Y-%m-%d')
            if today.day == 1:
                interest_payment = amount * interest_rate / 12
                remaining_balance = amount + interest_payment
                self.execute_query('INSERT INTO transactions (amount, category, description, date, account_id) VALUES (?, ?, ?, ?, ?)',
                                   (remaining_balance, 'withdrawal', 'Monthly loan repayment', today.strftime('%Y-%m-%d'), account_id))
                self.update_account_balance(account_id, -amount)
                current_date += timedelta(days=30)
        print("Monthly transactions processed successfully.")

