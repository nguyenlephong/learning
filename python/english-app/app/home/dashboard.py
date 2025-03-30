import tkinter as tk
from tkinter import ttk, messagebox


class DashboardWindow:
    def __init__(self, root, user):
        self.root = root
        self.user = user
        self.root.title("Trang chủ")
        self.root.geometry("800x500")

        # Tạo layout chính
        self.create_sidebar()
        self.create_main_content()

    def create_sidebar(self):
        """Tạo thanh sidebar điều hướng"""
        sidebar = tk.Frame(self.root, bg="#2C3E50", width=200, height=500)
        sidebar.pack(side="left", fill="y")

        tk.Label(sidebar, text="MENU", bg="#2C3E50", fg="white", font=("Arial", 14, "bold")).pack(pady=10)

        menu_items = [("Dashboard", self.show_dashboard), ("Từ vựng", self.show_vocabulary)]

        if self.user["role"] == "admin":
            menu_items.append(("Quản lý tài khoản", self.show_user_management))

        menu_items.append(("Đăng xuất", self.logout))

        for text, command in menu_items:
            btn = tk.Button(sidebar, text=text, bg="#34495E", fg="white", font=("Arial", 12), command=command)
            btn.pack(fill="x", pady=5)

    def create_main_content(self):
        """Tạo khu vực nội dung chính"""
        self.main_frame = tk.Frame(self.root, bg="white", width=600, height=500)
        self.main_frame.pack(side="right", fill="both", expand=True)
        self.show_dashboard()  # Mặc định hiển thị Dashboard

    def show_dashboard(self):
        """Hiển thị màn hình Dashboard"""
        self.clear_main_frame()

        tk.Label(self.main_frame, text="Dashboard", font=("Arial", 16, "bold"), bg="white").pack(pady=10)

        # Thống kê
        stats_frame = tk.Frame(self.main_frame, bg="white")
        stats_frame.pack(pady=10)

        tk.Label(stats_frame, text="Số từ vựng: 100", font=("Arial", 12), bg="white").grid(row=0, column=0, padx=20)
        tk.Label(stats_frame, text="Người dùng: 50", font=("Arial", 12), bg="white").grid(row=0, column=1, padx=20)
        if self.user["role"] == "admin":
            tk.Label(stats_frame, text="Quản trị viên: 5", font=("Arial", 12), bg="white").grid(row=0, column=2,
                                                                                                padx=20)

    def show_vocabulary(self):
        """Hiển thị danh sách từ vựng"""
        self.clear_main_frame()
        tk.Label(self.main_frame, text="Danh sách từ vựng", font=("Arial", 16, "bold"), bg="white").pack(pady=10)
        # TODO: Thêm danh sách từ vựng

    def show_user_management(self):
        """Hiển thị quản lý tài khoản (Chỉ dành cho Admin)"""
        self.clear_main_frame()
        tk.Label(self.main_frame, text="Quản lý tài khoản", font=("Arial", 16, "bold"), bg="white").pack(pady=10)
        # TODO: Thêm giao diện quản lý tài khoản

    def clear_main_frame(self):
        """Xóa nội dung cũ trước khi hiển thị nội dung mới"""
        for widget in self.main_frame.winfo_children():
            widget.destroy()

    def logout(self):
        """Đăng xuất và quay về màn hình đăng nhập"""
        from auth.login import LoginWindow
        self.root.destroy()
        new_root = tk.Tk()
        LoginWindow(new_root)
        new_root.mainloop()