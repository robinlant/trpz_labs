import requests

BASE_URL = 'http://127.0.0.1:5004'

transaction_data = {
    'amount': 100,
    'category': 'groceries',
    'description': 'Grocery shopping',
    'date': '2023-01-01',
    'account_id': 1
}


recurring_transaction_data = {
    'amount': 50,
    'category': 'subscription',
    'description': 'Monthly subscription',
    'frequency': 'monthly',
    'account_id': 2
}


response = requests.post(f'{BASE_URL}/add_transaction', json=transaction_data)
print(response.json())


response = requests.post(f'{BASE_URL}/add_recurring_transaction', json=recurring_transaction_data)
print(response.json())

account_id = 1
response = requests.post(f'{BASE_URL}/process_recurring_transactions/{account_id}')
print(response.json())

category = 'groceries'
account_id = 1
response = requests.get(f'{BASE_URL}/get_last_transaction_date/{category}/{account_id}')
print(response.json())

response = requests.get(f'{BASE_URL}/get_all_transactions')
print(response.json())