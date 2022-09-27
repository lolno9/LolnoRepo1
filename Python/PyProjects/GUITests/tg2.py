#!/usr/bin/python   
from tkinter import *           # imports the Tkinter lib
root = Tk()             # create the root object
root.wm_title("Hello World")        # sets title of the window
root.configure(bg="#99B898")        # change the background color 
root.attributes("-fullscreen", True)    # set to fullscreen


#update the text in the label_1
def greeting():
    label_1["text"] = "Hello, " +name.get() +"!"

# we can exit when we press the escape key
def end_fullscreen(event):
    root.attributes("-fullscreen", False)



name = StringVar()          #store a string from the Entry widget input

label_1 = Label(root, text="Hello, World!", font="Verdana 26 bold",
            fg="#000",
            bg="#99B898")

label_2 = Label(root, text="What is your name?",  height=3,
            fg="#000",
            bg="#99B898")

entry_1 = Entry(root, textvariable = name)

#Add a button inside the window
Button = Button(root, text="Submit", command = greeting)


label_1.grid(row=0, column=0)
label_2.grid(row=1, column=0)
entry_1.grid(row=1, column=1) 
Button.grid(row=2, column=1)


root.bind("<Escape>", end_fullscreen)
root.mainloop()             # starts the GUI loop