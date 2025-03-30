import tkinter as tk
from tkinter import messagebox
from utils.validators import is_valid_email, is_valid_password
from utils.hash_utils import hash_password
from utils.database import load_database, save_database

class RegisterWindow:
    def __init__(self, root):
        self.root = root
        self.root.title("Đăng ký tài khoản")
        self.root.geometry("400x400")

        # Label và Entry cho Họ và tên
        tk.Label(root, text="Họ và tên:").pack(pady=5)
        self.entry_name = tk.Entry(root)
        self.entry_name.pack(pady=5)

        # Label và Entry cho Email
        tk.Label(root, text="Email:").pack(pady=5)
        self.entry_email = tk.Entry(root)
        self.entry_email.pack(pady=5)

        # Label và Entry cho Mật khẩu
        tk.Label(root, text="Mật khẩu:").pack(pady=5)
        self.entry_password = tk.Entry(root, show="*")
        self.entry_password.pack(pady=5)

        # Label và Entry cho Xác nhận Mật khẩu
        tk.Label(root, text="Xác nhận mật khẩu:").pack(pady=5)
        self.entry_confirm_password = tk.Entry(root, show="*")
        self.entry_confirm_password.pack(pady=5)

        # Nút Đăng ký
        self.btn_register = tk.Button(root, text="Đăng ký", command=self.register)
        self.btn_register.pack(pady=20)

    def register(self):
        """Xử lý đăng ký tài khoản."""
        name = self.entry_name.get().strip()
        email = self.entry_email.get().strip()
        password = self.entry_password.get().strip()
        confirm_password = self.entry_confirm_password.get().strip()

        # Kiểm tra dữ liệu đầu vào
        if len(name) < 2:
            messagebox.showerror("Lỗi", "Họ và tên phải có ít nhất 2 ký tự!")
            return

        if not is_valid_email(email):
            messagebox.showerror("Lỗi", "Email không hợp lệ!")
            return

        if not is_valid_password(password):
            messagebox.showerror("Lỗi", "Mật khẩu phải có ít nhất 8 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt!")
            return

        if password != confirm_password:
            messagebox.showerror("Lỗi", "Mật khẩu xác nhận không khớp!")
            return

        # Kiểm tra email đã tồn tại chưa
        database = load_database()
        for user in database["users"]:
            if user["email"] == email:
                messagebox.showerror("Lỗi", "Email đã được đăng ký!")
                return

        # Mã hóa mật khẩu và lưu vào JSON
        hashed_password = hash_password(password)
        new_user = {
            "name": name,
            "email": email,
            "password": hashed_password,
            "role": "user"
        }

        database["users"].append(new_user)
        save_database(database)
        messagebox.showinfo("Thành công", "Đăng ký thành công!")

        # Đóng cửa sổ sau khi đăng ký thành công
        self.root.destroy()

# Khởi chạy giao diện đăng ký
if __name__ == "__main__":
    root = tk.Tk()
    app = RegisterWindow(root)
    root.mainloop()