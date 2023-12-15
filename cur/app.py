from datetime import datetime
from multiprocessing import Process
from accounts_service.accounts_service import AccountsService as accounts_app
from cur.transactions_service.transaction_service import TransactionssSerice as transaction_app
from deposit_loans_service.deposit_loan_service import DepositAndLoanService as deposit_loan_app
from cur.statistic_service.statistic_service import StatisticService as statistic_app
import time
from copy import deepcopy
from cur.utils.reducedecor import reduce_decorator

class ServiceState:
    def __init__(self, start_function):
        self.start_function = start_function
        self.process = Process(target=start_function)
        self.is_running = False

    def start(self):
        if not self.process.is_alive():
            print(f"Service {self.start_function.__name__} is not running. Starting...")
            self.process.start()
            self.is_running = True
        else:
            print(f"Service {self.start_function.__name__} is already running.")
            self.is_running = True

    def stop(self):
        if self.process.is_alive():
            print(f"Stopping service {self.start_function.__name__}...")
            self.process.terminate()
            self.process.join()
            self.is_running = False
        else:
            print(f"Service {self.start_function.__name__} is not running.")

    @reduce_decorator('reduce_log.txt')
    def __reduce__(self):
        return (self.__class__, (self.start_function,))

    def clone(self):
        return deepcopy(self)

class ServiceStateFactory:
    _service_states = {}

    @staticmethod
    def get_service_state(start_function):
        if start_function not in ServiceStateFactory._service_states:
            ServiceStateFactory._service_states[start_function] = ServiceState(start_function)
        return ServiceStateFactory._service_states[start_function]

class LoggingServiceState(ServiceState):
    def __init__(self, start_function, log_file_path):
        super().__init__(start_function)
        self.log_file_path = log_file_path

    def log_message(self, message):
        timestamp = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
        log_entry = f"{timestamp} - {message}\n"
        with open(self.log_file_path, 'a') as log_file:
            log_file.write(log_entry)

    def start(self):
        super().start()
        self.log_message(f"{self.start_function.__name__} started")

    def stop(self):
        super().stop()
        self.log_message(f"{self.start_function.__name__} stopped")

if __name__ == '__main__':
    log_file_path = 'service_log.txt'

    accounts_state = LoggingServiceState(accounts_app, log_file_path)
    transaction_state = LoggingServiceState(transaction_app, log_file_path)
    deposit_loan_state = LoggingServiceState(deposit_loan_app, log_file_path)
    statistic_state = LoggingServiceState(statistic_app, log_file_path)

    states = [
        ServiceStateFactory.get_service_state(accounts_app),
        ServiceStateFactory.get_service_state(transaction_app),
        ServiceStateFactory.get_service_state(deposit_loan_app),
        ServiceStateFactory.get_service_state(statistic_app),
    ]

    for state in states:
        state.start()

    try:
        while True:
            time.sleep(10)
            for state in states:
                state.start()
    except KeyboardInterrupt:
        print("Exiting...")
        for state in states:
            state.stop()

