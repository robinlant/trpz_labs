import requests

base_url = 'http://127.0.0.1:5009'


response = requests.get(f'{base_url}/total_account_balance')
if response.status_code == 200:
    print('Last Transaction Date:', response.json())
else:
    print('Error:', response.text)