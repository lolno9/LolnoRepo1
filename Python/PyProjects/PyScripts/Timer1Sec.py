import shlex
from subprocess import Popen, PIPE
from threading import Timer

def run(cmd, timeout_sec):
    proc = Popen(shlex.split(cmd), stdout=PIPE, stderr=PIPE)
    timer = Timer(timeout_sec, proc.kill)
    try:
        timer.start()
        stdout, stderr = proc.communicate()
        print("a")
    finally:
        timer.cancel()

# Examples: both take 1 second
run("sleep 1", 5)  # process ends normally at 1 second
run("sleep 5", 1)  # timeout happens at 1 second
