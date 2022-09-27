#!/bin/bash
while true
do
	date +"%H-%M-%S--%Y-%m-%d";
	if ping -c 3 pidesktop &> /dev/null
	then
		echo "hostapd activo";
		date +"%H-%M-%S--%Y-%m-%d";
	else
		sudo systemctl restart hostapd.service;
		echo "hostapd reiniciado";
		date +"%H-%M-%S--%Y-%m-%d";
	fi
	sleep 15m;
done;
