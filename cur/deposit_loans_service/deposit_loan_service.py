from flask import Flask, request, jsonify
from cur.deposit_loans_service.deposit_loan_handler import DepositsLoansHandler

app = Flask(__name__)
handler = DepositsLoansHandler()

@app.route('/add_deposit', methods=['POST'])
def add_deposit():
    data = request.json
    account_id = data.get('account_id')
    amount = data.get('amount')
    interest_rate = data.get('interest_rate')
    term = data.get('term')

    deposit_id = handler.add_deposit(account_id, amount, interest_rate, term)
    return jsonify({'deposit_id': deposit_id})

@app.route('/add_loan', methods=['POST'])
def add_loan():
    data = request.json
    account_id = data.get('account_id')
    amount = data.get('amount')
    interest_rate = data.get('interest_rate')
    term = data.get('term')

    loan_id = handler.add_loan(account_id, amount, interest_rate, term)
    return jsonify({'loan_id': loan_id})

@app.route('/calculate_deposit_interest/<int:deposit_id>', methods=['GET'])
def calculate_deposit_interest(deposit_id):
    interest_amount = handler.calculate_deposit_interest(deposit_id)
    return jsonify({'interest_amount': interest_amount})

@app.route('/calculate_loan_interest/<int:loan_id>', methods=['GET'])
def calculate_loan_interest(loan_id):
    interest_amount = handler.calculate_loan_interest(loan_id)
    return jsonify({'interest_amount': interest_amount})

@app.route('/update_account_balance/<int:account_id>', methods=['POST'])
def update_account_balance(account_id):
    data = request.json
    new_balance = data.get('new_balance')

    handler.update_account_balance(account_id, new_balance)
    return jsonify({'message': 'Account balance updated successfully'})

@app.route('/display_loan_balance_by_month/<int:loan_id>', methods=['GET'])
def display_loan_balance_by_month(loan_id):
    handler.display_loan_balance_by_month(loan_id)
    return jsonify({'message': 'Loan balance displayed successfully'})

@app.route('/display_deposit_balance_by_month/<int:deposit_id>', methods=['GET'])
def display_deposit_balance_by_month(deposit_id):
    handler.display_deposit_balance_by_month(deposit_id)
    return jsonify({'message': 'Deposit balance displayed successfully'})

@app.route('/process_monthly_transaction', methods=['POST'])
def process_monthly_transaction():
    handler.process_monthly_transaction()
    return jsonify({'message': 'Monthly transactions processed successfully'})



def DepositAndLoanService():
    app.run(port=5002)