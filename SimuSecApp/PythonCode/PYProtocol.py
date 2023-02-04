import re
import hashlib
import os
import time
import sqlite3
import socket
import CreditCard
from datetime import timedelta
from SQL_ORM import Connection, USER_CREDS_TABLE_NAME

__author__ = "SimuSecLTD"

BUFFER  = 1024
CONN = Connection()

def split_data(data: str):
    return data.split(":::")

def get_data(data: str):
    return split_data(data)[1]

def current_unixtime_as_int() -> int:
    current_time = int(time.time()) # Time in seconds since the epoch (Unix Time)

    return current_time

def unix_time_plus_month():
    current_time = current_unixtime_as_int()
    time_plus_month = current_time + timedelta(days=30).total_seconds()
    return int(time_plus_month)

def validateEmail(username: str):
    # Gmail username regex pattern
    pattern = re.compile("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")

    # Check if the username matches the pattern
    if pattern.match(username):
        return "OK"
    else:
        return "NO"

def validatePassword(password: str):
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


def generate_response_key(data: str):
    splitted_data = split_data(data)

    # After split by ':::'
    handler   = splitted_data[0]
    form_data = splitted_data[1]

    if handler   == "TESTUSER":
        return 0
    elif handler == "TESTPASS":
        return 1

def get_email_and_password_from_client(sock: socket.socket):
    # Receive email and password from Client
    email_recvd = sock.recv(255) # Max Email length -> 254
    passw_recvd = sock.recv(25) # Max passw length -> 24

    # Extract the data from the email, password
    email = get_data(email_recvd.decode())
    passw = get_data(passw_recvd.decode())

    return email, passw

def credential_validation_process(email: str, password: str):
    # Test the email and the password
    email_validation_res = validateEmail(email)
    passw_validation_res = validatePassword(password)

    if not(passw_validation_res == "OK" 
       and email_validation_res == "OK"):
            return "NO:::ERRORMSG" # Add implementation to errors later
    
    return f"OK:::{email}:::{password}"

def verify_license(license_end_date: int):
    return (license_end_date - current_unixtime_as_int()) > 0

def check_user_exists(email: str) -> bool:
    if CONN.find_in_database(table_name="UserCreds", to_find="Email",
                             value=email):
        return True
    
    return False

def validate_user_for_login(email: str, password: str):
    all_values = CONN.find_in_database(table_name="UserCreds", to_find="Email",
                             value=email)
    
    if not all_values: return "NO"

    # all values should return a 3 value tuple of (str, str, int)
    email_found       = all_values[0]
    password_found    = all_values[1]
    license_end_found = all_values[2]

    # Email and password should be the same, validate the hash and a valid license
    if email == email_found and verify_password(password, password_found)\
                            and verify_license(license_end_found):
        return "OK"
    
    return "NO"

def login(sock: socket.socket):
    email, passw = get_email_and_password_from_client(sock)

    ver_res = credential_validation_process(email, passw)

    splitted_res = split_data(ver_res)

    ver_code = splitted_res[0]

    if ver_code == "OK":
        email = splitted_res[1]
        passw = splitted_res[2]

        validation_code = validate_user_for_login(email, passw)

        if validation_code == "OK":
            sock.send("OK".encode())
        
        else:
            sock.send("ERRORMSG".encode())

    sock.send("ERRORMSG".encode())

def signup(sock):
    email, passw = get_email_and_password_from_client(sock)

    ver_res = credential_validation_process(email, passw)

    splitted_res = split_data(ver_res)

    ver_code = splitted_res[0]

    if ver_code == "OK":
        email = splitted_res[1]
        passw = splitted_res[2]

        sock.send("OK".encode())

        # Adding user to the database
        CONN.write_to_database(USER_CREDS_TABLE_NAME, 
                              (email, hash_password(passw),
                               unix_time_plus_month()))
    
    else:
        sock.send("ERRORMSG".encode())

def recv_payment(sock: socket.socket):
    print("Got To Payment")

def act_by_action(action: str, sock: socket.socket): # What to do based on the action given by Client
    if action == "LOGIN":
        login(sock)

    elif action == "SIGNUP":
        signup(sock)
    
    elif action == "PAY":
        recv_payment(sock)
    
    else:
        print(f"Action: {action}, not found")
