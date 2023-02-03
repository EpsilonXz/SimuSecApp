import socket
import PYProtocol
import time
import sqlite3

class Server:
    def __init__(self) -> None:
        self.host = '127.0.0.1'
        self.port = 11111
        self.BUFFER = PYProtocol.BUFFER

        self.init_socket()

    def init_socket(self):
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        s.bind((self.host, self.port))
        
        print("Initialized socket")
        s.listen()

        self.cli_sock, self.cli_addr = s.accept()

        print(f"Client at {self.cli_addr} connected!")

        self.transcript_info()


    def generate_response(key, data):
        data = PYProtocol.get_data(data)

        if    key == 0: # Email Verification
            return PYProtocol.validateEmail(data)
        
        elif  key == 1: # Password Verification
            return PYProtocol.validatePassword(data)


    def transcript_info(self):
        while True:
            action = self.cli_sock.recv(100).decode()
            
            PYProtocol.act_by_action(action, self.cli_sock)

            print("Done")
            break
        

if __name__ == "__main__":
    server = Server()  
