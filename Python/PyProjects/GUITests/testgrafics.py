import tkinter
from tkinter import ttk
raiz = tkinter.Tk()
raiz.geometry("300x200") #WxH
raiz.configure(bg = "beige") #color de fondo
raiz.title("TestGrafics1") #titulo
#boton para salir de la aplicacion
ttk.Button(raiz, text="Salir", command=quit).pack(side="bottom")
raiz.mainloop() #inicio de la ventana
