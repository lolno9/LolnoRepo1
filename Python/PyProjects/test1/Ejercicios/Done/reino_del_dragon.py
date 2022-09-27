#Reino del Dragon
import random
import time
import sys

def introduccion():
    print("Estamos en una terra llena d dragones.")
    print("Delante tuyo ves dos cuevas, en una el dragon es amigable")
    print("y compartira su tesoro contigo. En la otra, un dragon")
    print("hambriento y codicioso te convertira en su comida.")
    print("")

def CambiarCueva():
    cueva = ""
    while cueva != "1" and cueva != "2":
        print("Ha que cueva quieres entrar? 1 o 2?")
        cueva = input()
    return cueva

def cheqcueva(CambiarCueva):
    print("Te acercas a la Cueva...")
    time.sleep(2)
    print("Esta oscuro y tenebroso...")
    time.sleep(2)
    print("Un gran dragon salta delante tuyo, abre su boca y...")
    print("")
    time.sleep(2)
    FriendlyCueva = random.randint(1,2)
    if CambiarCueva == str(FriendlyCueva):
        print("Ten entrega el tesoro...")
    else:
        print("El dragon te come de un bocado...")
print(sys.version)
EmpezarNuevo = ("si")
while EmpezarNuevo ==("s") or EmpezarNuevo == ("si"):
    introduccion()
    NumCaverna = CambiarCueva()
    cheqcueva(NumCaverna)
    print("Quieres jugar de nuevo? (si o no)")
    EmpezarNuevo = input()
