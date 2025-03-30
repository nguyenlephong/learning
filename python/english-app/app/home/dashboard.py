import tkinter as tk
from tkinter import ttk, messagebox

class DashboardWindow:
    def __init__(self, root, user):
        self.root = root
        self.root.title("Trang chủ - Dashboard")
        self.root.geometry("800x500")
        self.user = user

        # Frame sidebar
        self.sidebar = tk.Frame(root, bg="#2C3E50", width=200, height=500)
        self.sidebar.pack(side="left", fill="y")

        # Frame nội dung chính
        self.main_content = tk.Frame(root, bg="white", width=600, height=500)
        self.main_content.pack(side="right", fill="both", expand=True)

        # Menu điều hướng
        self.menu_items = [
            ("Dashboard", self.show_dashboard),
            ("Từ vựng", self.show_vocabulary),
            ("Quản lý tài khoản", self.show_user_management) if user["role"] == "admin" else None,
            ("Đăng xuất", self.logout),
        ]

        for item in self.menu_items:
            if item:
                btn = tk.Button(self.sidebar, text=item[0], fg="white", bg="#34495E", font=("Arial", 12),
                                command=item[1], width=20, height=2, relief="flat")
                btn.pack(pady=5)

        self.show_dashboard()

    def show_dashboard(self):
        """Hiển thị giao diện Dashboard"""
        for widget in self.main_content.winfo_children():
            widget.destroy()

        tk.Label(self.main_content, text="Dashboard", font=("Arial", 16, "bold"), bg="white").pack(pady=10)

        stats_frame = tk.Frame(self.main_content, bg="white")
        stats_frame.pack(pady=10)

        ttk.Label(stats_frame, text="Số lượng từ vựng: 0", font=("Arial", 12)).pack(pady=5)
        ttk.Label(stats_frame, text="Số lượng người dùng: 0", font=("Arial", 12)).pack(pady=5)
        ttk.Label(stats_frame, text="Số lượng quản trị viên: 0", font=("Arial", 12)).pack(pady=5)

    def show_vocabulary(self):
        """Hiển thị giao diện quản lý từ vựng"""
        messagebox.showinfo("Thông báo", "Chức năng này sẽ được thêm sau!")

    def show_user_management(self):
        """Hiển thị giao diện quản lý tài khoản"""
        messagebox.showinfo("Thông báo", "Chức năng này sẽ được thêm sau!")

    def logout(self):
        from auth.login import LoginWindow
        self.root.destroy()
        new_root = tk.Tk()
        LoginWindow(new_root)
        new_root.mainloop()