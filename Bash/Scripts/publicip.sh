#!/bin/bash
printf "eth0 \n"
ifconfig eth0 | grep "inet "
host myip.opendns.com resolver1.opendns.com | awk '{print $4}' | tail -1
