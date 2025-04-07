import json
import os

DATABASE_PATH = "app/data/database.json"
WORD_DATABASE_PATH = "app/data/vocabulary.json"


def load_database():
    """Tải dữ liệu từ file JSON."""
    if not os.path.exists(DATABASE_PATH):
        return {"users": []}

    with open(DATABASE_PATH, "r", encoding="utf-8") as file:
        return json.load(file)


def save_database(data):
    """Lưu dữ liệu vào file JSON."""
    with open(DATABASE_PATH, "w", encoding="utf-8") as file:
        json.dump(data, file, indent=4, ensure_ascii=False)

def load_word_database():
    """Tải dữ liệu từ file JSON."""
    if not os.path.exists(WORD_DATABASE_PATH):
        return []

    with open(WORD_DATABASE_PATH, "r", encoding="utf-8") as file:
        return json.load(file)


def save_word_database(data):
    """Lưu dữ liệu vào file JSON."""
    with open(WORD_DATABASE_PATH, "w", encoding="utf-8") as file:
        json.dump(data, file, indent=4, ensure_ascii=False)