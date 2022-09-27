from cx_Freeze import setup, Executable

setup(name = "HelloWorldGUI" ,
      version = "0.1" ,
      description = "Test GUI with Tkinter" ,
      executables = [Executable("HelloWorldGUI.py")])