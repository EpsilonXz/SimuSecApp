import re

def split_data(data):
    return data.split(":::")

def get_data(data):
    return split_data(data)[1]

def validateEmail(username):
    # Gmail username regex pattern
    pattern = re.compile("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")

    # Check if the username matches the pattern
    if pattern.match(username):
        return "OK"
    else:
        return "NO"

def validatePassword(password):
    # Password regex pattern (minimum 8 characters, 1 uppercase, 1 lowercase, 1 digit)
    pattern = re.compile("^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")

    # Check if the password matches the pattern
    if pattern.match(password):
        return "OK"
    else:
        return "NO"

