#!/bin/bash

cont=2
while [ $cont -le 21 ]
do
	ping -c 5 10.0.0.$cont
	cont = $((cont + 1))
done 
