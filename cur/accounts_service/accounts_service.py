from flask import Flask, request, jsonify
from cur.accounts_service.accounts_handler import AccountsHandler, DatabaseHandler

app = Flask(__name__)


db_handler = DatabaseHandler()
accounts_handler = AccountsHandler(db_handler)

@app.route('/add_account', methods=['POST'])
def add_account():
    data = request.get_json()
    name = data.get('name')
    balance = data.get('balance')

    if name is None or balance is None:
        return jsonify({"error": "Name and balance are required"}), 400

    accounts_handler.add_account(name, balance)
    return jsonify({"message": "Account added successfully"})

@app.route('/get_all_accounts', methods=['GET'])
def get_all_accounts():
    all_accounts = accounts_handler.get_all_accounts()
    return jsonify({"accounts": all_accounts})

def AccountsService():
    app.run(port=5001)
