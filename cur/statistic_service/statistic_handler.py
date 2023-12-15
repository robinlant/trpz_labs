import sqlite3
import pandas as pd
from flask import g
from cur.config import path_to_db


class Statistichandler:
    def __init__(self, db_path=path_to_db):
        self.db_path = db_path

    def execute_query(self, query, parameters=None, commit=False, use_global_conn=False):
        if not use_global_conn:
            conn = sqlite3.connect(self.db_path)
            cursor = conn.cursor()
        else:
            conn = getattr(g, '_database', None)
            if conn is None:
                conn = g._database = sqlite3.connect(self.db_path)
            cursor = conn.cursor()

        if parameters is None:
            parameters = ()
        cursor.execute(query, parameters)
        if commit:
            conn.commit()
            conn.close()
        return cursor

    def get_last_transaction_date(self, category, account_id):
        query = 'SELECT MAX(date) FROM transactions WHERE category = ? AND account_id = ?'
        cursor = self.execute_query(query, (category, account_id), use_global_conn=True)
        return cursor.fetchone()[0]

    def get_all_transactions(self):
        query = 'SELECT * FROM transactions'
        cursor = self.execute_query(query, use_global_conn=True)
        return cursor.fetchall()

    def get_all_accounts(self):
        query = 'SELECT * FROM accounts'
        cursor = self.execute_query(query, use_global_conn=True)
        return cursor.fetchall()

    def get_total_expenses(self, start_date=None, end_date=None):
        query = 'SELECT SUM(amount) FROM transactions WHERE amount < 0'
        if start_date:
            query += ' AND date >= ?'
        if end_date:
            query += ' AND date <= ?'

        cursor = self.execute_query(query, (start_date, end_date), use_global_conn=True)
        total_expenses = cursor.fetchone()[0]
        return total_expenses if total_expenses else 0

    def get_average_monthly_expenses(self):
        query = 'SELECT AVG(amount) FROM transactions WHERE amount < 0 GROUP BY strftime("%Y-%m", date)'
        cursor = self.execute_query(query, use_global_conn=True)
        average_expenses = cursor.fetchone()[0]
        return average_expenses if average_expenses else 0

    def get_total_income(self, start_date=None, end_date=None):
        query = 'SELECT SUM(amount) FROM transactions WHERE amount > 0'
        if start_date:
            query += ' AND date >= ?'
        if end_date:
            query += ' AND date <= ?'

        cursor = self.execute_query(query, (start_date, end_date), use_global_conn=True)
        total_income = cursor.fetchone()[0]
        return total_income if total_income else 0

    def get_average_transaction_amount(self):
        query = 'SELECT AVG(amount) FROM transactions'
        cursor = self.execute_query(query, use_global_conn=True)
        average_transaction_amount = cursor.fetchone()[0]
        return average_transaction_amount if average_transaction_amount else 0

    def get_total_account_balance(self):
        query = 'SELECT SUM(balance) FROM accounts'
        cursor = self.execute_query(query, use_global_conn=True)
        total_balance = cursor.fetchone()[0]
        return total_balance if total_balance else 0

    def get_transaction_count(self, start_date=None, end_date=None):
        query = 'SELECT COUNT(*) FROM transactions'
        if start_date or end_date:
            query += ' WHERE'
            if start_date:
                query += ' date >= ?'
            if start_date and end_date:
                query += ' AND'
            if end_date:
                query += ' date <= ?'

        parameters = (start_date, end_date) if start_date or end_date else None
        cursor = self.execute_query(query, parameters, use_global_conn=True)
        transaction_count = cursor.fetchone()[0]
        return transaction_count if transaction_count else 0

    def get_largest_income(self):
        query = 'SELECT MAX(amount) FROM transactions WHERE amount > 0'
        cursor = self.execute_query(query, use_global_conn=True)
        largest_income = cursor.fetchone()[0]
        return largest_income if largest_income else 0

    def get_expenses_by_category(self, start_date=None, end_date=None):
        query = 'SELECT category, SUM(amount) FROM transactions WHERE amount < 0'
        if start_date:
            query += ' AND date >= ?'
        if end_date:
            query += ' AND date <= ?'
        query += ' GROUP BY category'

        cursor = self.execute_query(query, (start_date, end_date), use_global_conn=True)
        expenses_by_category = cursor.fetchall()
        return expenses_by_category

    def export_to_excel(self, filename='financial_data.xlsx'):
        query = 'SELECT * FROM transactions'
        cursor = self.execute_query(query, use_global_conn=True)
        transactions = cursor.fetchall()
        df = pd.DataFrame(transactions, columns=['id', 'amount', 'category', 'description', 'date'])
        df.to_excel(filename, index=False)

    def export_statistics_to_excel(self):
        total_expenses_january = self.get_total_expenses('2023-01-01', '2023-01-31')
        average_monthly_expenses = self.get_average_monthly_expenses()
        average_transaction_amount = self.get_average_transaction_amount()
        total_account_balance = self.get_total_account_balance()
        transaction_count = self.get_transaction_count()
        largest_income = self.get_largest_income()
        expenses_by_category = self.get_expenses_by_category('2023-01-01', '2023-02-28')
        total_income = self.get_total_income('2023-01-01', '2023-02-28')

        data = {
            'Total Expenses (January)': [total_expenses_january],
            'Average Monthly Expenses': [average_monthly_expenses],
            'Average Transaction Amount': [average_transaction_amount],
            'Total Account Balance': [total_account_balance],
            'Transaction Count': [transaction_count],
            'Largest Income': [largest_income],
            'Total Income': [total_income]
        }

        df_expenses_by_category = pd.DataFrame(expenses_by_category, columns=['Category', 'Total Expenses'])
        with pd.ExcelWriter('financial_statistics.xlsx', engine='xlsxwriter') as writer:
            df_expenses_by_category.to_excel(writer, sheet_name='Expenses by Category', index=False)
            pd.DataFrame(data).to_excel(writer, sheet_name='Overall Statistics', index=False)

        print("Statistics exported to financial_statistics.xlsx")