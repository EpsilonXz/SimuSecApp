import socket
import PYProtocol
from _thread import *
import os

CONNECTED_USERS = dict()
TEMP_KEYS = dict()

class Server:
    def __init__(self) -> None:
        self.host = '192.168.14.24'
        self.port = 11120
        self.BUFFER = PYProtocol.BUFFER

        self.init_socket()

    def init_socket(self):
        self.s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.s.bind((self.host, self.port))
        
        from PyPhisher.pyphisher import init_server

        start_new_thread(init_server, ())

        print("Initialized socket")
        self.s.listen()

        self.connection()
    
    def connection(self):
        while True:
            try:
                cli_sock, cli_addr = self.s.accept()
            except:
                self.s.close()
                exit()

            print(f"Client at {cli_addr} connected!")
            try:
                start_new_thread(self.transcript_info, (cli_sock, ))
            except:
                pass

    def transcript_info(self, cli_sock: socket.socket):
        global CONNECTED_USERS
        global TEMP_KEYS
        # Generate a random encryption key and IV
        key, iv = PYProtocol.generate_and_send_key(cli_sock)
        TEMP_KEYS.update({cli_sock: {"key": key, "iv": iv}})

        while True:
            data = PYProtocol.recv(cli_sock)
            try:
                action = data[0]
            except:
                print(f"Client Disconnected")
                CONNECTED_USERS.pop(cli_sock)
                cli_sock.close()
                return
            
            data.pop(0)
            
            if action == "LOGOUT":
                CONNECTED_USERS.pop(cli_sock)

            PYProtocol.act_by_action(action, data, cli_sock)
        
if __name__ == "__main__":
    server = Server()  
