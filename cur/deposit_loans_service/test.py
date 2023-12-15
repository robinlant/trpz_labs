import requests


base_url = "http://127.0.0.1:5002"


add_deposit_url = f"{base_url}/add_deposit"
deposit_data = {"account_id": 1, "amount": 1000, "interest_rate": 0.05, "term": 12}
response = requests.post(add_deposit_url, json=deposit_data)
print("Add Deposit Response:", response.text)


add_loan_url = f"{base_url}/add_loan"
loan_data = {"account_id": 2, "amount": 5000, "interest_rate": 0.08, "term": 24}
response = requests.post(add_loan_url, json=loan_data)
print("Add Loan Response:", response.text)


calculate_deposit_interest_url = f"{base_url}/calculate_deposit_interest/1"
response = requests.get(calculate_deposit_interest_url)
print("Calculate Deposit Interest Response:", response.text)


calculate_loan_interest_url = f"{base_url}/calculate_loan_interest/2"
response = requests.get(calculate_loan_interest_url)
print("Calculate Loan Interest Response:", response.text)


update_account_balance_url = f"{base_url}/update_account_balance/1"
balance_data = {"new_balance": 5000}
response = requests.post(update_account_balance_url, json=balance_data)
print("Update Account Balance Response:", response.text)


# display_loan_balance_by_month_url = f"{base_url}/display_loan_balance_by_month/1"
# response = requests.get(display_loan_balance_by_month_url)
# print("Display Loan Balance by Month Response:", response.text)
#
#
# display_deposit_balance_by_month_url = f"{base_url}/display_deposit_balance_by_month/1"
# response = requests.get(display_deposit_balance_by_month_url)
# print("Display Deposit Balance by Month Response:", response.text)


# process_monthly_transaction_url = f"{base_url}/process_monthly_transaction"
# response = requests.post(process_monthly_transaction_url)
# print("Process Monthly Transaction Response:", response.text)
