#!/bin/sh
while true; do
	host myip.opendns.com resolver1.opendns.com | awk '{print $4}' | tail -1
	#host myip.opendns.com resolver1.opendns.com
	sleep 30;
done;
