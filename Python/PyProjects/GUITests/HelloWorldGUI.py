import tkinter

def greeting():
    label_1["text"] = "Hello, "+name.get()+"!"

def end_fullscreen(event):
    root.attributes("-fullscreen", False)
    
root = tkinter.Tk()
root.wm_title("Hello World")
root.configure(bg="black")
root.geometry("800x480")
root.attributes("-fullscreen", True) #or root.geometry("800x480")
root.bind("<Escape>", end_fullscreen) #if go fullscreen tu be able to exit
name = tkinter.StringVar()
label_1 = tkinter.Label(root, text="Hello, World!", font="Verdana 26 bold",
                        fg="#00FF41",
                        bg="black")
label_2 = tkinter.Label(root, text="What's your name?", height=3, font="Verdana 16 bold",
                        fg="#00FF41",
                        bg="black")
entry_1 = tkinter.Entry(root, textvariable=name, font="Verdana 16 bold")
button = tkinter.Button(root, text="Submit", command= greeting,
                        font="Verdana 16",
                        fg="#00FF41",
                        bg="black")
label_1.grid(row=0, column=0)
label_2.grid(row=1, column=0)
entry_1.grid(row=1, column=1)
button.grid(row=2, column=1)
entry_1.focus()
root.mainloop()