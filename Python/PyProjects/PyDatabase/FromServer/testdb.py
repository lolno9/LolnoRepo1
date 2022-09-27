#!/usr/bin/python3
import pymysql
db = pymysql.connect("localhost","pi","DevLolno","world")
cursor = db.cursor()
cursor.execute("SELECT VERSION()")
data = cursor.fetchone()
print ("Database version: %s" % data)
cursor.execute("SHOW TABLES")
data = cursor.fetchall()
print ("Tables: ")
for dat in data:
	print (dat,dat[0])
cursor.execute("DESCRIBE city")
data = cursor.fetchall()
for dat in data:
	print (dat[0],"  ",dat[1],"  ",dat[2],"  ",dat[3],"  ",dat[4],"  ",dat[5])
db.close()
