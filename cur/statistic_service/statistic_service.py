from flask import Flask, jsonify
from cur.statistic_service.statistic_handler import Statistichandler

app = Flask(__name__)
stat_handler = Statistichandler()

@app.route('/last_transaction_date/<category>/<int:account_id>')
def last_transaction_date(category, account_id):
    result = stat_handler.get_last_transaction_date(category, account_id)
    return jsonify({'last_transaction_date': result})

@app.route('/all_transactions')
def all_transactions():
    result = stat_handler.get_all_transactions()
    return jsonify({'all_transactions': result})

@app.route('/all_accounts')
def all_accounts():
    result = stat_handler.get_all_accounts()
    return jsonify({'all_accounts': result})

@app.route('/total_expenses')
def total_expenses():
    result = stat_handler.get_total_expenses()
    return jsonify({'total_expenses': result})

@app.route('/average_monthly_expenses')
def average_monthly_expenses():
    result = stat_handler.get_average_monthly_expenses()
    return jsonify({'average_monthly_expenses': result})

@app.route('/total_income')
def total_income():
    result = stat_handler.get_total_income()
    return jsonify({'total_income': result})

@app.route('/average_transaction_amount')
def average_transaction_amount():
    result = stat_handler.get_average_transaction_amount()
    return jsonify({'average_transaction_amount': result})

@app.route('/total_account_balance')
def total_account_balance():
    result = stat_handler.get_total_account_balance()
    return jsonify({'total_account_balance': result})

@app.route('/transaction_count')
def transaction_count():
    result = stat_handler.get_transaction_count()
    return jsonify({'transaction_count': result})

@app.route('/largest_income')
def largest_income():
    result = stat_handler.get_largest_income()
    return jsonify({'largest_income': result})

@app.route('/expenses_by_category')
def expenses_by_category():
    result = stat_handler.get_expenses_by_category()
    return jsonify({'expenses_by_category': result})

def StatisticService():
    app.run(port=5009)
