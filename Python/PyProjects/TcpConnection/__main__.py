import tcpserver
import tcpclient

def main():
    ip = input("Ip: ")
    port = input("Puerto: ")
    lop = True
    while lop:
        opcion = input("Envias o recibes datos?(e/r) ")
        if opcion == "r":
            cli = tcpclient.Recv_Data(ip,int(port))
            lop = False
        elif opcion == "e":
            srvr = tcpserver.Transfer(ip,int(port))
            lop = False
        else:
            lop = True

if __name__ == "__main__":
    main()
