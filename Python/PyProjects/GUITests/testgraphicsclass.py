import tkinter
import tkinter.ttk

class Aplicacion():
    def __init__(self):
        raiz = tkinter.Tk()
        raiz.geometry("300x200")
        raiz.configure(bg = "beige")
        raiz.title("Aplicacion")
        tkinter.ttk.Button(raiz, text="Salir", command=raiz.destroy).pack(side="bottom")
        raiz.mainloop()

def main():
    mi_app = Aplicacion()
    return 0

if __name__ == "__main__":
    main()
