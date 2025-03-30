from auth.register import RegisterWindow
import tkinter as tk

if __name__ == "__main__":
    root = tk.Tk()
    app = RegisterWindow(root)
    root.mainloop()