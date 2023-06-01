import sqlite3
import os.path

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
DB_NAME = "SimuSecDB.db"
db_path = os.path.join(BASE_DIR, "../database/" + DB_NAME)

USER_CREDS_TABLE_NAME = "UserCreds"
SALTS_INFO_TABLE_NAME = "UserSalts"

class Connection:
    def __init__(self):
        self.conn, self.cur = self.open_database()

    def open_database(self):
        conn = sqlite3.connect(db_path, check_same_thread=False)
        c    = conn.cursor()

        return conn, c

    def add_user(self, values, salt):
        self.cur.execute(f"INSERT INTO {USER_CREDS_TABLE_NAME}\
                                VALUES {values}")
        print(values[0])
        self.cur.execute(f"INSERT INTO {SALTS_INFO_TABLE_NAME}\
                                VALUES ('{values[0]}', '{salt}')")
        
        self.conn.commit()

    def get_user_creds(self, email):
        self.cur.execute(f"SELECT * FROM {USER_CREDS_TABLE_NAME} WHERE Email='{email}'")

        to_return = self.cur.fetchone()

        self.conn.commit()

        return to_return

    def get_user_salt(self, email:str):
        self.cur.execute(f"SELECT Salt FROM {SALTS_INFO_TABLE_NAME} WHERE Email='{email}'")

        to_return = self.cur.fetchone()

        self.conn.commit()

        return to_return
    
    def update_license_date(self, email, new_date):
        self.cur.execute(f"UPDATE {USER_CREDS_TABLE_NAME} SET LicenseEndDate= '{new_date}' WHERE Email='{email}'")
        
        bone = self.cur.fetchone()
        
        self.conn.commit()
    def user_exists(self, email):
        self.cur.execute(f"SELECT * FROM {USER_CREDS_TABLE_NAME} WHERE Email='{email}'")
        
        bone = self.cur.fetchone()
        
        self.conn.commit()
        
        if bone is not None:
            return True
        return False

        
    def close_database(self):
        self.conn.close()

