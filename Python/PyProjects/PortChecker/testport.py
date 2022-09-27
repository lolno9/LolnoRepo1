import portchecker, sys

print(sys.version)
ip = input("Ip a escanear: ")
minrange = input("Minimo puerto: ")
maxrange = input("Maximo puerto: ")

list = [i for i in range(int(minrange),int(maxrange)+1)]
print("Checking alive ports for "+ip)
for num in list:
    pc = portchecker.PortChecker(ip, num)
    if pc.checkHost(ip, num):
        print("Port: "+str(num)+" Alive")
    else:
        print("Port: "+str(num)+" Dead")
