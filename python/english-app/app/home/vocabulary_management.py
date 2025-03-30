import tkinter as tk
from tkinter import ttk, messagebox
import json

class VocabularyManagement(tk.Frame):
    def __init__(self, parent, user):
        super().__init__(parent, bg="white")
        self.parent = parent
        self.user = user

        self.create_ui()
        self.load_vocabulary_data()

    def create_ui(self):
        """Tạo giao diện quản lý từ vựng"""
        tk.Label(self, text="Quản lý từ vựng", font=("Arial", 16, "bold"), bg="white").pack(pady=10)

        # Thanh tìm kiếm và bộ lọc
        search_frame = tk.Frame(self, bg="white")
        search_frame.pack(pady=5, fill="x")

        tk.Label(search_frame, text="Tìm kiếm:", bg="white").pack(side="left", padx=5)
        self.search_entry = tk.Entry(search_frame)
        self.search_entry.pack(side="left", padx=5)
        tk.Button(search_frame, text="🔍", command=self.search_word).pack(side="left", padx=5)

        tk.Label(search_frame, text="Lọc theo loại từ:", bg="white").pack(side="left", padx=10)
        self.filter_combobox = ttk.Combobox(search_frame, values=["Tất cả", "Danh từ", "Động từ", "Tính từ"])
        self.filter_combobox.current(0)
        self.filter_combobox.pack(side="left", padx=5)
        tk.Button(search_frame, text="Lọc", command=self.filter_words).pack(side="left", padx=5)

        # Bảng hiển thị từ vựng
        columns = ("ID", "Từ vựng", "Loại từ", "Câu ví dụ", "Cụm từ")
        self.word_table = ttk.Treeview(self, columns=columns, show="headings", height=10)

        for col in columns:
            self.word_table.heading(col, text=col)
            self.word_table.column(col, width=120)

        self.word_table.pack(pady=10, fill="both", expand=True)

        # Nút thao tác (Chỉ dành cho Admin)
        if self.user["role"] == "admin":
            btn_frame = tk.Frame(self, bg="white")
            btn_frame.pack(pady=5)

            tk.Button(btn_frame, text="➕ Thêm từ mới", command=self.add_word).pack(side="left", padx=5)
            tk.Button(btn_frame, text="✏️ Chỉnh sửa", command=self.edit_word).pack(side="left", padx=5)
            tk.Button(btn_frame, text="❌ Xóa", command=self.delete_word).pack(side="left", padx=5)
            tk.Button(btn_frame, text="📂 Nhập JSON", command=self.import_json).pack(side="left", padx=5)
            tk.Button(btn_frame, text="💾 Xuất JSON", command=self.export_json).pack(side="left", padx=5)

    def load_vocabulary_data(self):
        """Load danh sách từ vựng từ file JSON và hiển thị trên bảng"""
        try:
            with open("app/data/vocabulary.json", "r", encoding="utf-8") as file:
                vocabulary_list = json.load(file)

            self.word_table.delete(*self.word_table.get_children())  # Clear bảng trước khi load mới

            for item in vocabulary_list:
                self.word_table.insert("", "end", values=(
                    item.get("id", ""),
                    item.get("word", ""),
                    ", ".join(item.get("verb", []) or []),
                    ", ".join(item.get("sentences", []) or []),
                    ", ".join(item.get("phrases", []) or [])
                ))

        except Exception as e:
            messagebox.showerror("Lỗi", f"Không thể tải dữ liệu từ vựng: {e}")

    def search_word(self):
        """Lọc danh sách từ vựng dựa trên từ khóa nhập vào"""
        keyword = self.search_entry.get().strip().lower()

        if not keyword:
            self.load_vocabulary_data()  # Nếu không nhập gì, hiển thị toàn bộ danh sách
            return

        # Tạo danh sách mới chứa các từ vựng phù hợp
        filtered_words = []
        try:
            with open("app/data/vocabulary.json", "r", encoding="utf-8") as file:
                vocabulary_list = json.load(file)

            # Tìm từ vựng khớp với giá trị tìm kiếm
            for word in vocabulary_list:
                word_text = word.get("word", "").lower()  # Lấy từ vựng và chuyển về chữ thường
                sentences = word.get("sentences", [])  # Lấy danh sách câu ví dụ

                # Kiểm tra nếu từ khóa có trong từ vựng
                is_in_word = keyword in word_text

                # Kiểm tra nếu từ khóa có trong bất kỳ câu ví dụ nào
                is_in_sentences = False
                for sentence in sentences:
                    if keyword in sentence.lower():
                        is_in_sentences = True
                        break  # Nếu tìm thấy trong 1 câu, không cần kiểm tra tiếp

                # Nếu từ khóa xuất hiện trong từ vựng hoặc câu ví dụ, thêm vào danh sách kết quả
                if is_in_word or is_in_sentences:
                    filtered_words.append(word)

            # Xóa dữ liệu cũ trước khi cập nhật bảng
            self.word_table.delete(*self.word_table.get_children())

            for item in filtered_words:
                self.word_table.insert("", "end", values=(
                    item.get("id", ""),
                    item.get("word", ""),
                    ", ".join(item.get("verb", []) or []),
                    ", ".join(item.get("sentences", []) or []),
                    ", ".join(item.get("phrases", []) or [])
                ))

        except Exception as e:
            messagebox.showerror("Lỗi", f"Không thể tìm kiếm từ vựng: {e}")

    def filter_words(self):
        """Lọc từ vựng (Chưa triển khai)"""
        pass

    def add_word(self):
        """Thêm từ vựng (Chưa triển khai)"""
        pass

    def edit_word(self):
        """Chỉnh sửa từ vựng (Chưa triển khai)"""
        pass

    def delete_word(self):
        """Xóa từ vựng (Chưa triển khai)"""
        pass

    def import_json(self):
        """Nhập từ JSON (Chưa triển khai)"""
        pass

    def export_json(self):
        """Xuất từ JSON (Chưa triển khai)"""
        pass