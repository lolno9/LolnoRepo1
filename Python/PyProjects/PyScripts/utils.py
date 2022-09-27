#Limpiar pantalla tanto en linux como en windows(ambas son lo mismo)
#Primero usando system
import os
def clear():
    if os.name == "nt":
        _ = os.system("cls")
    else:
        _ = os.system("clear")
#Segundo usando subprocess
""" 
import subprocess
def clear():
    _ = call('clear' if os.name =='posix' else 'cls')
"""
