from datetime import datetime
from functools import wraps


def reduce_decorator(log_file_path):
    def decorator(method):
        @wraps(method)
        def wrapper(self, *args, **kwargs):
            current_time = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            with open(log_file_path, 'a') as log_file:
                log_file.write(f"{current_time} - {self.start_function.__name__}: {method.__name__} called\n")
            result = method(self, *args, **kwargs)
            with open(log_file_path, 'a') as log_file:
                log_file.write(f"{current_time} - {self.start_function.__name__}: {method.__name__} completed\n")
            return result
        return wrapper
    return decorator