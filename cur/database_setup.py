import sqlite3

class DatabaseSetup:
    def __init__(self, db_path='finance.db'):
        self.conn = sqlite3.connect(db_path)
        self.cursor = self.conn.cursor()

    def create_tables(self):
        self.cursor.execute('''
            CREATE TABLE IF NOT EXISTS transactions (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                amount REAL,
                category TEXT,
                description TEXT,
                date DATE,
                account_id INTEGER
            )
        ''')

        self.cursor.execute('''
            CREATE TABLE IF NOT EXISTS accounts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT,
                balance REAL
            )
        ''')

        self.cursor.execute('''
            CREATE TABLE IF NOT EXISTS deposits (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                account_id INTEGER,
                amount REAL,
                interest_rate REAL,
                term INTEGER,
                FOREIGN KEY (account_id) REFERENCES accounts(id)
            )
        ''')

        self.cursor.execute('''
            CREATE TABLE IF NOT EXISTS loans (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                account_id INTEGER,
                amount REAL,
                interest_rate REAL,
                term INTEGER,
                paid_amount REAL DEFAULT 0,
                paid_interest REAL DEFAULT 0,
                FOREIGN KEY (account_id) REFERENCES accounts(id)
            )
        ''')

        self.conn.commit()

test = DatabaseSetup()
test.create_tables()