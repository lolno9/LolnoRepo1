import sys
import os
import time

def comprimir_descomprimir(comando):
    print(comando)
    os.system(comando)

def construir_comandoc_tar(archivo, archivoc):
    return "tar -cvf "+archivoc+".tar"+" "+archivo

def construir_comandoc_gz(archivo):
    return "gzip -9 "+archivo+".tar"

def construir_comandoc_zip(archivo, archivoc):
    return "zip -r "+archivoc+".zip"+" "+archivo

print(sys.version)
print("")
""" arg1 a comprimir arg2 comprimido"""
acomprimir = sys.argv[1]
if len(sys.argv) < 3:
   comprimido = ""
else:
   comprimido = sys.argv[2]
#TODO reconocer y comprimir en formato .zip ---
if len(sys.argv) < 4:
   tipo = ""
else:
   tipo = sys.argv[3]
if tipo == "tar": #--Este fragmento comprime en .tar y seguidamente en .gz
   print("Generando comando compresion .tar")
   time.sleep(1)
   cmdtar = construir_comandoc_tar(acomprimir,comprimido)
   print("Comprimiendo")
   comprimir_descomprimir(cmdtar)
   time.sleep(3)
   print("Comprimido")
   print("Generando comando compresion .gz")
   time.sleep(1)
   cmdgz = construir_comandoc_gz(comprimido)
   print("Comprimiendo")
   comprimir_descomprimir(cmdgz)
   time.sleep(3)
   print("Comprimido") #--
#---
if tipo == "zip":
   print("Generando comando compresion .zip")
   time.sleep(1)
   cmdzip = construir_comandoc_zip(acomprimir,comprimido)
   print("Comprimiendo")
   comprimir_descomprimir(cmdzip)
   time.sleep(3)
   print("Comprimido")
