from setuptools import setup, find_packages

# Read the contents of your README file
with open("README.md", "r", encoding="utf-8") as fh:
    long_description = fh.read()

# Read the list of requirements
with open("requirements.txt", "r", encoding="utf-8") as fh:
    required_packages = fh.read().splitlines()

setup(
    name="english-learning-app",
    version="0.1.0",
    author="PhongNguyen",
    author_email="phongnguyen.itengineer@gmail.com",
    description="A PoC project about English learning app",
    long_description=long_description,
    long_description_content_type="text/markdown",
    url="https://github.com/nguyenlephong/learning",
    packages=find_packages(),
    install_requires=required_packages,
    classifiers=[
        "Programming Language :: Python :: 3",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
    ],
    python_requires='>=3.6',
)