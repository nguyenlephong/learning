import tkinter as tk
from tkinter import filedialog
import json

# Sample data to save
data = {"name": "John", "age": 30, "city": "New York"}

# Function to save JSON file
def save_json():
    root = tk.Tk()
    root.withdraw()  # Hide the main tkinter window

    file_path = filedialog.asksaveasfilename(
        defaultextension=".json",
        filetypes=[("JSON files", "*.json"), ("All Files", "*.*")]
    )

    if file_path:
        with open(file_path, "w") as json_file:
            json.dump(data, json_file, indent=4)
        print(f"File saved at: {file_path}")

# Call the function
save_json()
