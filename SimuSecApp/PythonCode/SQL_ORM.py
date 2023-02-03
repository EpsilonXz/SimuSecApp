import sqlite3

DB_NAME = "SimuSecDB.db"
USER_CREDS_TABLE_NAME = "UserCreds"

class Connection:
    def __init__(self):
        self.conn, self.cur = self.open_database()

    def open_database(self):
        conn = sqlite3.connect("database\\" + DB_NAME)
        c    = conn.cursor()

        return conn, c

    def write_to_database(self, table_name, values):
        self.cur.execute(f"INSERT INTO {table_name}\
                                VALUES {values}")

        self.conn.commit()


    def find_in_database(self, table_name, to_find, value):
        self.cur.execute(f"SELECT * FROM {table_name} WHERE {to_find}='{value}'")

        to_return = self.cur.fetchone()

        self.conn.commit()

        return to_return

    def close_database(self):
        self.conn.close()