import tkinter
import tkinter.ttk

class Aplicacion():
    def __init__(self):
#sin el uso de self no podriamos acceder desde otros metodos
        self.raiz = tkinter.Tk()
        self.raiz.geometry("300x200")
        self.raiz.resizable(width=False, height=False)
        self.raiz.title("Ver Info")
#definimos widget text en el k se puede poner mas de una linea de texto
        self.tinfo = tkinter.Text(self.raiz, width=40, height=10)
        self.tinfo.pack(side="top")
        self.binfo = tkinter.ttk.Button(self.raiz, text="Info", command=self.verinfo)
        self.binfo.pack(side="left")
        self.bsalir = tkinter.ttk.Button(self.raiz, text="Salir", command = self.raiz.destroy)
        self.bsalir.pack(side="right")
        self.binfo.focus_set()
        self.raiz.mainloop()

    def verinfo(self):
        self.tinfo.delete(1.0, tkinter.END)
        info1 = self.raiz.winfo_class()
        info2 = self.raiz.winfo_geometry()
        info3 = str(self.raiz.winfo_width())
        info4 = str(self.raiz.winfo_height())
        info5 = str(self.raiz.winfo_rootx())
        info6 = str(self.raiz.winfo_rooty())
        info7 = str(self.raiz.winfo_id())
        info8 = self.raiz.winfo_name()
        info9 = self.raiz.winfo_manager()
        texto_info = "Clase de 'raiz': "+info1+"\n"
        texto_info += "Resolución y posición: "+info2+"\n"
        texto_info += "Anchura ventana: "+info3+"\n"
        texto_info += "Altura ventana: "+info4+"\n"
        texto_info += "Pos. Ventana X: "+info5+"\n"
        texto_info += "Pos. Ventana Y: "+info6+"\n"
        texto_info += "Id. de 'raiz': "+info7+"\n"
        texto_info += "Nombre objeto: "+info8+"\n"
        texto_info += "Gestor ventanas: "+info9+"\n"
        self.tinfo.insert("1.0", texto_info)
def main():
    mi_app = Aplicacion()
    return 0
if __name__ == "__main__":
    main()
