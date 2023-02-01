import re
import hashlib
import os
import time

BUFFER = 1024

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


def hash_password(password: str):
    # Generate a random 16-byte salt
    salt = os.urandom(16)
    
    # Hash the password using the salt and the SHA-256 algorithm
    password_hash = hashlib.pbkdf2_hmac('sha256', password.encode(), salt, 100000)
    
    # Combine the salt and the password hash and return the result as a hexadecimal string
    return (salt + password_hash).hex()

def verify_password(password: str, password_hash: str):
    # Convert the hexadecimal password hash string back to bytes
    salt = bytes.fromhex(password_hash[:32])
    
    # Hash the entered password using the same salt and SHA-256 algorithm
    password_hash_candidate = hashlib.pbkdf2_hmac('sha256', password.encode(), salt, 100000)
    
    # Compare the resulting password hash to the stored password hash
    return password_hash_candidate.hex() == password_hash[32:]


def login_validation(cli_sock):
    username = cli_sock.recv(BUFFER).decode()
    print(username)
    username = get_data(username)
    
    time.sleep(0.1)
    usernameVal = validateEmail(username)
    passwd = cli_sock.recv(BUFFER).decode()
    print(passwd)
    passwd = get_data(passwd)
    
    time.sleep(0.1)
    passwdVal = validatePassword(passwd)
    return usernameVal, passwdVal
        