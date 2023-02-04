import re
from datetime import datetime

def luhn_checksum(card_number):
    # Return the digits of a given number
    def digits_of(n):
        return [int(d) for d in str(n)]
    
    # Extract the digits from the card number
    digits = digits_of(card_number)
    
    # Split the digits into odd and even sets
    odd_digits = digits[-1::-2]
    even_digits = digits[-2::-2]
    
    # Calculate the Luhn checksum
    checksum = 0
    checksum += sum(odd_digits)
    for d in even_digits:
        checksum += sum(digits_of(d*2))
    return checksum % 10

def is_luhn_valid(card_number):
    # Check if the length of the card number is between 13 and 19 digits
    if len(str(card_number)) < 13 or len(str(card_number)) > 19:
        return False
    
    # Return whether the Luhn checksum is valid
    return luhn_checksum(card_number) == 0

def is_valid_cardholder_name(cardholder_name):
    # Check if the cardholder name only contains letters and spaces
    if re.match("^[a-zA-Z ]*$", cardholder_name):
        return True
    return False

def is_valid_expiration_date(expiration_date):
    # Check if the expiration date is in the future
    current_date = datetime.now()
    
    # Extract the expiration month and year from the date string
    expiration_month = int(expiration_date[:2])
    expiration_year = int("20" + expiration_date[3:5])
    
    # Check if the expiration date is in the future
    if current_date.year < expiration_year:
        return True
    elif current_date.year == expiration_year:
        if current_date.month < expiration_month:
            return True
    return False

def is_valid_cvv(cvv):
    # Check if the CVV is 3 digits long
    if len(str(cvv)) == 3:
        return True
    return False

def is_valid_card_info(card_number, cardholder_name, expiration_date, cvv):
    # Check if all the card information is valid
    if is_luhn_valid(card_number)\
    and is_valid_cardholder_name(cardholder_name)\
    and is_valid_expiration_date(expiration_date)\
    and is_valid_cvv(cvv):
        return True
    return False

# Example usage
#card_number = 4388576018402626
#cardholder_name = "John Doe"
#expiration_date = "12/24"
#cvv = 123
