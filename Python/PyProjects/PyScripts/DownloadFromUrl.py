import urllib.request
import shutil

url = input("URL: ")
file_name = input("File Name: ")

with urllib.request.urlopen(url) as response, open(file_name, 'wb') as out_file:
    shutil.copyfileobj(response, out_file)
