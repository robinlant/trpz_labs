from flask import Flask, jsonify, request
from cur.transactions_service.transactions_handler import TransactionsHandler

app = Flask(__name__)
transactions_handler = TransactionsHandler()


@app.route('/add_transaction', methods=['POST'])
def add_transaction():
    data = request.json
    amount = data['amount']
    category = data['category']
    description = data['description']
    date = data.get('date')
    account_id = data.get('account_id')

    transactions_handler.add_transaction(amount, category, description, date, account_id)

    return jsonify({'status': 'success'})

@app.route('/process_recurring_transactions/<int:account_id>', methods=['POST'])
def process_recurring_transactions(account_id):
    transactions_handler.process_recurring_transactions(account_id)
    return jsonify({'status': 'success'})

@app.route('/get_all_transactions', methods=['GET'])
def get_all_transactions():
    all_transactions = transactions_handler.get_all_transactions()
    return jsonify({'transactions': all_transactions})


@app.route('/import_from_excel', methods=['POST'])
def import_from_excel():
    filename = request.json['filename']
    transactions_handler.import_from_excel(filename)
    return jsonify({'status': 'success'})

@app.route('/get_last_transaction_date/<category>/<int:account_id>', methods=['GET'])
def get_last_transaction_date(category, account_id):
    conn = transactions_handler.get_db()
    cursor = conn.cursor()
    last_transaction_date = transactions_handler.get_last_transaction_date(category, account_id, cursor)
    return jsonify({'last_transaction_date': last_transaction_date})


@app.route('/add_recurring_transaction', methods=['POST'])
def add_recurring_transaction():
    data = request.json
    amount = data['amount']
    category = data['category']
    description = data['description']
    frequency = data['frequency']
    account_id = data['account_id']
    transactions_handler.add_recurring_transaction(amount, category, description, frequency, account_id)
    return jsonify({'status': 'success'})




def TransactionssSerice():
    app.run(port=5004)