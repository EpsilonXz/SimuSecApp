import socket
import PYProtocol
import time

class Server:
    def __init__(self) -> None:
        self.host = '127.0.0.1'
        self.port = 11111
        self.BUFFER = 1024

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
        username = self.cli_sock.recv(self.BUFFER).decode()
        print(username)
        username = PYProtocol.get_data(username)
        
        time.sleep(0.1)
        usernameVal = PYProtocol.validateEmail(username)

        self.cli_sock.send(usernameVal.encode())

        passwd = self.cli_sock.recv(self.BUFFER).decode()
        print(passwd)
        passwd = PYProtocol.get_data(passwd)
        
        time.sleep(0.1)
        passwdVal = PYProtocol.validatePassword(passwd)

        self.cli_sock.send(passwdVal.encode())
        
    

    


if __name__ == "__main__":
    server = Server()
    
