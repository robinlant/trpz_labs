import sqlite3
from flask import g

from cur.config import path_to_db


class AccountsHandler:
    def __init__(self, implementation):
        self.implementation = implementation

    def add_account(self, name, balance):
        self.implementation.add_account(name, balance)

    def get_all_accounts(self):
        return self.implementation.get_all_accounts()

class DatabaseHandler:
    def __init__(self, db_path= path_to_db):
        self.db_path = db_path

    def get_db(self):
        db = getattr(g, '_database', None)
        if db is None:
            db = g._database = sqlite3.connect(self.db_path)
        return db

    def execute_query(self, query, parameters=None):
        if parameters is None:
            parameters = ()
        cursor = self.get_db().cursor()
        cursor.execute(query, parameters)
        self.get_db().commit()
        return cursor

    def add_account(self, name, balance):
        self.execute_query('''
            INSERT INTO accounts (name, balance)
            VALUES (?, ?)
        ''', (name, balance))

    def get_all_accounts(self):
        cursor = self.execute_query('SELECT * FROM accounts')
        return cursor.fetchall()