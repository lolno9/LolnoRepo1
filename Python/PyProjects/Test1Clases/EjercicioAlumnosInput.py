class Alumno:
    #inicializamos los atributos
    def __init__(self):
        self.nombre = input("Nombre del Alumno: ")
        self.nota = input("Nota final: ")
        
    def imprimir(self):
        print("Alumno: ", self.nombre)
        print("Nota: ", self.nota)
        print("")
        
    def resultado(self):
        if int(self.nota) < 5:
            print("El alumno ha suspendido")
        else:
            print("El alumno ha aprovado")
        
alumno1 = Alumno()
alumno2 = Alumno()

alumno1.imprimir()
alumno1.resultado()

alumno2.imprimir()
alumno2.resultado()