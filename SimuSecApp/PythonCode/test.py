import os

class Spoofer:
    def __init__(self) -> None:
        self.ZW1haWw = "your-email-for-validation-smtp-server"
        self.TWFzdGVyIFBhc3N3b3Jk = "master-password-of-smtp-server"
        self.server = "smtp-server-location"
        self.port = 587 # The port of the smtp server

    def spoof(self, from_addr, to_addr, Header, Body, sender_full_fake_name):
        os.system(f'sendemail -xu {self.ZW1haWw} -xp {self.TWFzdGVyIFBhc3N3b3Jk} -s {self.server}:{self.port}\
                  -f {from_addr} -t {to_addr}, -u {Header} -m {Body} -o message-header="From: {sender_full_fake_name}\
                  <{from_addr}>"')

sp = Spoofer()