#!/bin/sh
clear
echo "Let's Go"
./mypubip.dev& echo $! > pidscript
cat pidscript
echo "\n Done"
