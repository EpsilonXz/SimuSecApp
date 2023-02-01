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

        self.transcript_info();

    def transcript_info(self):
        usernameVal, passwdVal = PYProtocol.login_validation(self.cli_sock)
        print(usernameVal)
        self.cli_sock.send(usernameVal.encode())
        self.cli_sock.send(passwdVal.encode())
        
    

    


if __name__ == "__main__":
    server = Server()
    
