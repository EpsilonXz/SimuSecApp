from SQL_ORM import Connection

if __name__ == "__main__":
    connection = Connection()
    found = connection.find_in_database("UserCreds", "Email", "email@gmail.com")
    

    #connection.write_to_database("UserCreds", ("email@gmail.com", "Mewto12345", 1675427764))
    if found:
        print("done")

    else:
        print("ERROR-001")




