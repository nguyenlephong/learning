# Ứng dụng quản lý từ vựng Tiếng Anh


## Source Structure

```tree
project_root/
│── app/
│   │── main.py                     # Điểm khởi chạy ứng dụng
│   │── config.py                    # Cấu hình chung của ứng dụng
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
│   │   │── database.py               # Kết nối và xử lý database
│   │
│   │── assets/                        # Chứa tài nguyên như icon, ảnh
│   │── data/                          # Chứa file JSON dữ liệu từ vựng
│
│── requirements.txt                   # Danh sách thư viện cần cài đặt
│── README.md                          # Hướng dẫn sử dụng
│── .gitignore                          # Các file cần bỏ qua khi đẩy lên git
```

## Cài đặt

```bash
pip install -r requirements.txt
```


## How to run

```python

python app/main.py
```