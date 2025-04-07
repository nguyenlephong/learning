import tkinter as tk
from tkinter import messagebox
from utils.validators import is_valid_email, is_valid_password
from utils.hash_utils import hash_password
from utils.database import load_database, save_database
from common.configs import WINDOW_SIZE

class RegisterWindow:
    def __init__(self, root):
        self.root = root
        self.root.title("Đăng ký tài khoản")

        # Khởi tạo màn hình ở vị trí giữa cửa sổ
        screen_width = self.root.winfo_screenwidth()
        screen_height = self.root.winfo_screenheight()
        x = int((screen_width / 2) - (WINDOW_SIZE['WIDTH'] / 2))
        y = int((screen_height / 2) - (WINDOW_SIZE['HEIGHT'] / 2))
        self.root.geometry(f"{WINDOW_SIZE['WIDTH']}x{WINDOW_SIZE['HEIGHT']}+{x}+{y}")

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
        self.btn_register.pack(pady=10)

        self.btn_back = tk.Button(root, text="Quay lại Đăng nhập", command=self.open_login_window)
        self.btn_back.pack(pady=5)

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
        new_user = {"name": name, "email": email, "password": hashed_password, "role": "user"}

        database["users"].append(new_user)
        save_database(database)
        messagebox.showinfo("Thành công", "Đăng ký thành công!")

        self.open_login_window()

    def open_login_window(self):
        """Import LoginWindow here to avoid circular import."""
        from auth.login import LoginWindow  # ✅ Import only inside function
        self.root.destroy()
        new_root = tk.Tk()
        LoginWindow(new_root)
        new_root.mainloop()