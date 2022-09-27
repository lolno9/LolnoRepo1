import sys

def riman(palabra1, palabra2):
    if palabra1[-3:].upper() == palabra2[-3:].upper():
        print("Riman")
    elif palabra1[-2:].upper() == palabra2[-2:].upper():
        print("Riman un poco")
    else:
        print("No riman")
print(sys.version)
print("palabras1= hola mola")
riman("hola","mola")
print("palabras2= hola mula")
riman("hola","mula")
print("palabras3= hola adios")
riman("hola","adios")
