import tkinter as tk
from tkinter import ttk, messagebox

class UserManagement(tk.Frame):
    def __init__(self, parent, user):
        super().__init__(parent)
        self.parent = parent
        self.user = user
        self.create_ui()
        self.load_user_data()

    def create_ui(self):
        """Create the user management interface."""
        tk.Label(self, text="User Management", font=("Arial", 16, "bold")).pack(pady=10)

        # Frame for action buttons
        action_frame = tk.Frame(self)
        action_frame.pack(fill="x", padx=10, pady=5)

        tk.Button(action_frame, text="➕ Add User", command=self.add_user).pack(side="left", padx=5)

        # Search and filter frame
        search_frame = tk.Frame(self)
        search_frame.pack(fill="x", padx=10, pady=5)

        tk.Label(search_frame, text="Search:").pack(side="left", padx=5)
        self.search_entry = tk.Entry(search_frame)
        self.search_entry.pack(side="left", padx=5)
        tk.Button(search_frame, text="🔍", command=self.search_user).pack(side="left", padx=5)

        tk.Label(search_frame, text="Filter by Role:").pack(side="left", padx=10)
        self.filter_combobox = ttk.Combobox(search_frame, values=["All", "Admin", "Editor", "Viewer"])
        self.filter_combobox.current(0)
        self.filter_combobox.pack(side="left", padx=5)
        tk.Button(search_frame, text="Filter", command=self.filter_users).pack(side="left", padx=5)

        # User table
        columns = ("User ID", "Username", "Role", "Actions")
        self.user_table = ttk.Treeview(self, columns=columns, show="headings", height=10)

        for col in columns:
            self.user_table.heading(col, text=col)
            if col == "Actions":
                self.user_table.column(col, width=150, anchor="center")
            else:
                self.user_table.column(col, width=120)

        self.user_table.pack(pady=10, fill="both", expand=True)

    def load_user_data(self):
        """Load user data into the table."""
        # Example user data
        users = [
            {"id": 1, "username": "admin", "role": "Admin"},
            {"id": 2, "username": "editor1", "role": "Editor"},
            {"id": 3, "username": "viewer1", "role": "Viewer"},
        ]

        for user in users:
            self.insert_user(user)

    def insert_user(self, user):
        """Insert a user into the table with action buttons."""
        item = self.user_table.insert("", "end", values=(user["id"], user["username"], user["role"], ""))
        btn_frame = tk.Frame(self.user_table)
        tk.Button(btn_frame, text="✏️ Edit", command=lambda: self.edit_user(user["id"])).pack(side="left", padx=2)
        tk.Button(btn_frame, text="❌ Delete", command=lambda: self.delete_user(user["id"])).pack(side="left", padx=2)
        self.user_table.item(item, values=(user["id"], user["username"], user["role"], btn_frame))
        self.user_table.update_idletasks()

    def add_user(self):
        """Open form to add a new user."""
        # Implementation for adding a new user
        pass

    def edit_user(self, user_id):
        """Open form to edit the selected user."""
        # Implementation for editing a user
        pass

    def delete_user(self, user_id):
        """Delete the selected user."""
        # Implementation for deleting a user
        pass

    def search_user(self):
        """Search users based on the input."""
        # Implementation for searching users
        pass

    def filter_users(self):
        """Filter users based on the selected role."""
        # Implementation for filtering users
        pass

if __name__ == "__main__":
    root = tk.Tk()
    UserManagement(root).pack(fill="both", expand=True)
    root.mainloop()