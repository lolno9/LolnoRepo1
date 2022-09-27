import sys
import time
import random
import utils
#podemos generar mas de 9 digitos, pero lo podemos capar a 9 si queremos
def generar_numero(longitud):
    lista = []
    cont = 0
    while cont < longitud:
        lista.insert(cont, random.randint(0,9))
        cont += 1
    return lista

def comprovar_numero(numero, lista):
    aciertos = 0
    cont = 0
    while cont < len(lista):
        if numero[cont] == lista[cont]:
            aciertos += 1
        cont += 1
    return aciertos

print(sys.version)
intentos = 5
lista = generar_numero(int(input("Longitud del numero? (2 - 9) ")))
print("Generando numero...")
print("Numero generado.")
contador = 0
while contador < intentos:
    numero = input("Intenta adivinar el numero, tienes "+str(intentos-contador)+" intentos:  ")
    num2 = list(map(int,str(numero)))
    resultado = comprovar_numero(num2,lista)
    if resultado == len(numero):
        print("Con "+str(numero)+" has adivinado "+str(resultado)+" digitos. Felicidades")
    else:
        print("Con "+str(numero)+" has adivinado "+str(resultado)+" digitos.")
    contador += 1
