class Alumno:
    #inicializamos los atributos
    def __init__(self, nombre, nota):
        self.nombre = nombre
        self.nota = nota
        
    def imprimir(self):
        print("Alumno: ", self.nombre)
        print("Nota: ", self.nota)
        print("")
        
    def resultado(self):
        if self.nota < 5:
            print("El alumno ha suspendido")
        else:
            print("El alumno ha aprovado")
        
alumno1 = Alumno("Diego", 4)
alumno2 = Alumno("Sofia", 10)

alumno1.imprimir()
alumno1.resultado()

alumno2.imprimir()
alumno2.resultado()