import tkinter as tk
from tkinter import messagebox
from utils.hash_utils import hash_password
from utils.database import load_database

class LoginWindow:
    def __init__(self, root):
        self.root = root
        self.root.title("Đăng nhập")
        self.root.geometry("400x300")

        tk.Label(root, text="Email:").pack(pady=5)
        self.entry_email = tk.Entry(root)
        self.entry_email.pack(pady=5)

        tk.Label(root, text="Mật khẩu:").pack(pady=5)
        self.entry_password = tk.Entry(root, show="*")
        self.entry_password.pack(pady=5)

        self.btn_login = tk.Button(root, text="Đăng nhập", command=self.login)
        self.btn_login.pack(pady=10)

        self.btn_register = tk.Button(root, text="Đăng ký tài khoản", command=self.open_register_window)
        self.btn_register.pack(pady=5)

    def login(self):
        """Xử lý đăng nhập."""
        email = self.entry_email.get().strip()
        password = self.entry_password.get().strip()

        database = load_database()

        for user in database["users"]:
            if user["email"] == email and user["password"] == hash_password(password):
                messagebox.showinfo("Thành công", "Đăng nhập thành công!")
                self.root.destroy()
                return

        messagebox.showerror("Lỗi", "Email hoặc mật khẩu không đúng!")

    def open_register_window(self):
        """Import RegisterWindow here to avoid circular import."""
        from auth.register import RegisterWindow  # ✅ Import only inside function
        self.root.destroy()
        new_root = tk.Tk()
        RegisterWindow(new_root)
        new_root.mainloop()