import socket
import time

class PortChecker():
    def __init__(self, ip1, port1):
        self.ip = ip1
        self.port = port1
        self.retry = 5
        self.delay = 1
        self.timeout = 3

    def isOpen(self, ip, port):
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        s.settimeout(self.timeout)
        try:
            s.connect((ip, int(port)))
            s.shutdown(socket.SHUT_RDWR)
            return True
        except:
            return False
        finally:
            s.close()

    def checkHost(self, ip, port):
        ipup = False
        for i in range(self.retry):
            if self.isOpen(ip, port):
                ipup = True
                break
            else:
                time.sleep(self.delay)
        return ipup
