import ejercicios2 as ejer2
import sys
print(sys.version)

print("test ejercicio1 WORKS")
lista = [1332,2,3,4,5,5,6,7,33]
rese1 = ejer2.max_in_list(lista)
print(rese1)
print("test ejercicio2 WORK")
lista = ["hola","adios","mañana","esdujula","hoy"]
print(ejer2.mas_larga(lista))
print("test ejercicio3 WORKS")
lista = ["hola","adios","mañana","esdujula","hoy"]
print(ejer2.filtrar_palabras(lista, 5))
print("test ejercicio4 WORKS")
cadena = "AdIoS" #input("Introduce una cadena: ")
totmayus = ejer2.total_mayusculas(cadena)
print("La cadena contiene "+str(totmayus)+" mayuscúlas")
print("test ejercicio5 WORKS")
print(str(ejer2.binario_a_decimal("11111111")))
print(str(ejer2.decimal_a_binario(255)))
print("test ejercicio6 WORKS")
print(str(ejer2.calcular_edad(1993,2019)))
print("test ejercicio7 WORKS")
tupla = (1,2,3,4,5,6,7,8,9,0,10)
print(str(ejer2.max_en_lista(tupla)))
print("test ejercicio8 WORKS")
lista = ("antonio","alba","john","mike")
print(ejer2.buscar_letra_inicio(lista,"a"))
print("test ejercicio9 WORKS")
print("Hola")
print(ejer2.contar_vocales("Hola"))
print("test ejercicio10 WORKS")
print("Es bisiesto" if ejer2.es_bisiesto(2020) else "No es bisiesto")
