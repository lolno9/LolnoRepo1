import socket, sys, threading

from time import sleep
#reserved ports < 1024
class Recv_Data :
   # self.host, self.port = "", 0
    """mysocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    mysocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    mysocket.connect(self.host, self.port)"""

    def __init__(self, ip, puerto):
        self.host = ip
        self.port = puerto
        mysocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        mysocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        print(self.host+" "+str(self.port))
        mysocket.connect((self.host, self.port))
        fn = input(" File name: ")
        data = mysocket.recv(1024)
        f = open(fn, 'wb')
        while data != bytes(''.encode()):
            #print(data)
            f.write(data)
            data = mysocket.recv(1024)
""" 
    mysocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    mysocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    print(host+" "+str(port))
    mysocket.connect((self.host, self.port))
"""
