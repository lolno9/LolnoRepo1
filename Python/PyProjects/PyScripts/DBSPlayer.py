import os
import sys
import time
import utils

print(sys.version)
print("")
print("Scanning for videos files...")
f = open("videos","r")
if f.mode == "r":
    contents = f.read()
    for content in contents.splitlines():
        print("Playing: "+str(content[21:]))
        print("Controls: q exit, 1 + spd, 2 - spd, - and + vol, space pause")
        os.system("omxplayer -r -o hdmi "+content)
        time.sleep(2)
        utils.clear()