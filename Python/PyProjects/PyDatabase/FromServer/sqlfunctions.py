#!/usr/bin/python3
import pymysql

def dbconnect(host, user, pswd, dbname):
	db = pymysql.connect(host,user,pswd,dbname)
	cursor = db.cursor()
	return db, cursor

def dbchkcnt(cursor):
	cursor.execute("SELECT VERSION()")
	print (cursor.fetchone())
	return

def dbtblinf(cursor):
	return

def dbcloser(db):
	db.close()
	return

