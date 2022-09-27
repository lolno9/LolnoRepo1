#encuentra el numero mas grande de una lista
def max_in_list(lista):
    resultado = 0
    for numero in lista:
        if resultado < numero:
            resultado = numero
    return resultado
#encuentra la palabra mas larga de una lista de palabras
def mas_larga(lista):
    cont1 = 0
    cont2 = 0
    maslarga = ""
    for palabra in lista:
        cont1 = 0
        for char in palabra:
            cont1 += 1
        if cont2 < cont1:
            cont2 = cont1
            maslarga = palabra
    return maslarga

def filtrar_palabras(lista, minimo):
    cont1 = 0
    resultado = ""
    for palabra in lista:
        cont1 = 0
        for char in palabra:
            cont1 += 1
        if minimo < cont1:
            resultado = resultado+palabra+","
    listafinal = resultado.split(",")
    listafinal.pop()
    return listafinal

def total_mayusculas(cadena):
    contm = 0
    for char in cadena:
        if char.isspace():
            contm = contm 
        elif char == char.upper():
            contm += 1
    return contm

def binario_a_decimal(numerobinario):
    return int(numerobinario, 2)

def decimal_a_binario(numerodecimal):
    return bin(numerodecimal)[2:].zfill(8)

def calcular_edad(nacimiento, actual):
    return actual - nacimiento

def max_en_lista(lista):
    resultado = 0
    for num in lista:
        if num > resultado:
            resultado = num
    return resultado
def buscar_letra_inicio(lista,letra):
    resultado = []
    for nombre in lista:
        if nombre[0:1] == letra:
            resultado.insert(len(resultado),nombre)
    return resultado

def contar_vocales(palabra):
    cont1 = 0
    cont2 = 0
    vocales = ("a","e","i","o","u")
    totalvocales = []
    for vocal in vocales:
        nletras = 0
        for char in palabra:
            if char.upper() == vocal.upper():
                nletras += 1
        totalvocales.insert(cont2, str(vocales[cont2])+": "+str(nletras))
        cont2 += 1
    return totalvocales

def es_bisiesto(anyo):
    if anyo % 4 == 0 and anyo % 100 != 0:
        return True
    elif anyo % 400 == 0:
        return True
    else:
        return False
