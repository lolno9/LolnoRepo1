#!/bin/bash
host myip.opendns.com resolver1.opendns.com | awk '{print $4}' | tail -1
exit 0
