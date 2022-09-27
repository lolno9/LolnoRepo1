#list absolute path and content of a dir
import subprocess
import os
import sys

def get_running_path():
    return str(os.path.dirname(os.path.abspath(__file__)))

def set_dir_destino(directorio):
    os.chdir(os.path.abspath(directorio))

print(sys.version)
diractu = get_running_path()
dirdestino = set_dir_destino(input("Directorio a buscar?: "))
process = subprocess.run(["ls"], check = True, stdout = subprocess.PIPE, universal_newlines = True)
output = process.stdout
resout = output.split()
print("Running path: "+get_running_path())
for res in resout:
    print(get_running_path()+res)
