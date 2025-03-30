# Ứng dụng quản lý từ vựng Tiếng Anh


## Source Structure

```tree
project_root/
│── app/
│   │── main.py                     # Điểm khởi chạy ứng dụng
│   │── config.py                    # Cấu hình chung của ứng dụng
│   │── database.py                   # Kết nối và xử lý database
│   │── auth/                         
│   │   │── login.py                  # Xử lý đăng nhập
│   │   │── register.py               # Xử lý đăng ký
│   │   │── auth_utils.py             # Hàm tiện ích cho xác thực người dùng
│   │
│   │── models/                       
│   │   │── user_model.py             # Định nghĩa model User
│   │   │── vocabulary_model.py       # Định nghĩa model Vocabulary
│   │
│   │── views/                        
│   │   │── login_view.py             # Giao diện đăng nhập
│   │   │── register_view.py          # Giao diện đăng ký
│   │   │── dashboard_view.py         # Giao diện trang chủ
│   │   │── vocabulary_view.py        # Giao diện danh sách từ vựng
│   │   │── user_management_view.py   # Giao diện quản lý tài khoản
│   │   │── profile_view.py           # Giao diện hồ sơ cá nhân
│   │
│   │── controllers/                  
│   │   │── user_controller.py        # Xử lý logic tài khoản
│   │   │── vocabulary_controller.py  # Xử lý logic từ vựng
│   │   │── permission_controller.py  # Xử lý phân quyền
│   │
│   │── utils/                        
│   │   │── validators.py             # Xác thực dữ liệu đầu vào
│   │   │── file_handler.py           # Xử lý file nhập/xuất
│   │   │── message_box.py            # Hiển thị hộp thoại thông báo
│   │
│   │── assets/                        # Chứa tài nguyên như icon, ảnh
│   │── data/                          # Chứa file JSON dữ liệu từ vựng
│   │── exports/                       # Chứa file xuất từ vựng (JSON, CSV, PDF, TXT)
│   │── templates/                     # Chứa template giao diện nếu dùng Tkinter + ttkbootstrap
│
│── requirements.txt                   # Danh sách thư viện cần cài đặt
│── README.md                          # Hướng dẫn sử dụng
│── .gitignore                          # Các file cần bỏ qua khi đẩy lên git
```