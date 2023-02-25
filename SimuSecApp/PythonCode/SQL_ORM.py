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

    def add_user(self, values):
        self.cur.execute(f"INSERT INTO {USER_CREDS_TABLE_NAME}\
                                VALUES {values}")
        
        self.conn.commit()

    def get_user_creds(self, email):
        self.cur.execute(f"SELECT * FROM {USER_CREDS_TABLE_NAME} WHERE Email='{email}'")

        to_return = self.cur.fetchone()

        self.conn.commit()

        return to_return
    
    def user_exists(self, email):
        try:
            self.cur.execute(f"SELECT * FROM {USER_CREDS_TABLE_NAME} WHERE Email='{email}'")
        except:
            return False
        return True
    def close_database(self):
        self.conn.close()