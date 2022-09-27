import sqlite3
#iniciar y cerrar conexion con BD
con_bd = sqlite3.connect("contactos.db")
con_bd.close()
#declarar y cerrar un cursor
cursor_agenda = con_bd.cursor()
cursor_agenda.close()
#añadir registro a tabla
""" reg = (1,"A","a@a.a",1)
cursor_agenda.execute("INSERT INTO agenda VALUES(?,?,?,?)",reg)
con_bd.commit()""" #completa la insercion del registro en la tabla
#comprovar nombres de tablas
""" SELECT name FROM sqlite_master WHERE type = 'table'; """
#comprovar registros de tabla
cursor_agenda.execute("SELECT * FROM agenda")
for registro in cursor_agenda:
    print(registro)
#comprovar registro con parametro
par = (1,)
cursor_agenda.execute("SELECT * FROM agenda WHERE ident=?", par)
for registro in cursor_agenda:
    print(registro)
#comprovar registros tabla con fetchone()
cursor_agenda.execute("SELECT * FROM agenda WHERE ident>?", par)
registro = cursor_agenda.fetchone() # Lee el primer registro
print(registro)
#comprovar registro con fetchmany()
par = (0,)
cursor_agenda.execute("SELECT * FROM agenda WHERE ident>?", par)
registros = cursor_agenda.fetchmany(2)  # 2 registros
for registro in registros: print(registro)
#comprovar registros con fetchall()
cursor_agenda.execute("SELECT * FROM agenda WHERE ident>?", par)
registros = cursor_agenda.fetchall()
for registro in registros:
    print(registro)
#mostrar los campos del registro por posicion+par = (2,)
cursor_agenda.execute("SELECT * FROM agenda WHERE ident=?", par)
for campo in cursor_agenda:
    print("Identificador:", campo[0])
    print("Nombre.......:", campo[1])
#consultar registros por nombre de campo
con_bd = sqlite3.connect("contactos.db")
con_bd.row_factory = sqlite3.Row
cursor_agenda = con_bd.cursor()
cursor_agenda.execute("SELECT * FROM agenda WHERE ident=?", par)
registro = cursor_agenda.fetchone()
print("Nombre", registro['nombre'])
print("Correo", registro['ecorreo'])
#borrar registro
values = (1,)
cursor_agenda.execute('DELETE FROM agenda WHERE ident=?',values)
con_bd.commit()
#deshacer modificacion
con_bd.rollback()
