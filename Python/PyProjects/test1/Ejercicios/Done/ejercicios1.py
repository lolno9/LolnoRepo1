class Ejercicios1:
   def __init__(self):
       pass

   def max(self, numero1, numero2):
       if numero1 < numero2:
           return numero2
       elif numero1 > numero2:
           return numero1
       else:
           print("")
           print("Error al leer los numeros")
           print("")

   def max_de_tres(self, numero1, numero2, numero3):
       if numero1 > numero2 and numero1 > numero3:
           return numero1
       if numero2 > numero1 and numero2 > numero3:
           return numero2
       if numero3 > numero1 and numero3 > numero2:
           return numero3

   def longitud(self,var):
       i = 0
       if isinstance(var, str):
           print("El objeto es una cadena")
           for char in var:
               i += 1
           return i
       else:
           print("El objeto es una lista")
           for item in var:
               i += 1
           return i

   def esvocal(self, char):
       vocales = "aeiou"
       return char in vocales

   def sum(self, lista):
       num1 = 0
       for item in lista:
           num1 = num1 + int(item)
       return num1

   def multip(self, lista):
       num1 = 1
       for item in lista:
           num1 = num1 * int(item)
       return num1

   def inversa(self, cadena):
       cadena1 = ""
       for c in cadena:
           cadena1 = c + cadena1
       return cadena1

   def es_palindromo(self, cadena):
       cadenainv = self.inversa(cadena)
       if cadena == cadenainv:
           return True
       else:
           return False

   def superposicion(self, lista1, lista2):
       for item1 in lista1:
           for item2 in lista2:
               if item1 == item2 :
                   return True
       return False

   def generar_n_caracteres(self, num, char):
       generado = num * char
       return generado

   def procedimiento(self, lista):
           for item in lista:
               print(item * "x")#print(str(self.generar_n_caracteres(int(item),"*")))
