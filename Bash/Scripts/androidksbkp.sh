#!/bin/bash
test=$(date +"%H-%M-%S--%Y-%m-%d");
echo $test;
#mkdir "/home/lolnodleech/shared/linuxworkspace/"$test;
cp -r "/home/lolnodleech/shared/devenv/" "/home/lolnodleech/shared/androidworkspace/ksserver/"$test;
exit 0;
