#!/usr/bin/python3
import pymysql
import sqlfunctions as sqf
import subprocess as sp

#sqf = sqlfunctions
#clear screen 
sp.call("clear", shell=True)

"""TODO 
connect and show table info, work with selects
"""
# first print version(just tot tst this works)
basedata = sqf.dbconnect("localhost","pi", "DevLolno", "d_database")
sqf.dbchkcnt(basedata[1])
sqf.dbcloser(basedata[0])
