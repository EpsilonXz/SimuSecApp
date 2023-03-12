import os

class Spoofer:
    def __init__(self) -> None:
        self.ZW1haWw = "roicarm7@gmail.com"
        self.TWFzdGVyIFBhc3N3b3Jk = "cTJKUNrVRhs2jkw8"
        self.server = "smtp-relay.sendinblue.com"
        self.port = 587

        self.spoof("andrewtate@tate.com", "shalevshagan1@gmail.com", "Breath Air", "Vape is for losers! join: jointherealworld.com", "Andrew Tate")

    def spoof(self, from_addr, to_addr, Header, Body, sender_full_fake_name):
        os.system(f'sendemail -xu {self.ZW1haWw} -xp {self.TWFzdGVyIFBhc3N3b3Jk} -s {self.server}:{self.port}\
                  -f {from_addr} -t {to_addr}, -u {Header} -m {Body} -o message-header="From: {sender_full_fake_name}\
                  <{from_addr}>"')

sp = Spoofer()