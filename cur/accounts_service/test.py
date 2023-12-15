import requests

data = {"name": "Savings", "balance": 1000}
response = requests.post("http://127.0.0.1:5001/add_account", json=data)
print(response.json())

response = requests.get("http://127.0.0.1:5001/get_all_accounts")
print(response.json())