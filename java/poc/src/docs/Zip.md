## How to test

```bash
touch file1.txt
touch file2.txt
curl -X POST "http://localhost:8080/api/zip/compress" \
  -F "files=@file1.txt" \
  -F "files=@file2.txt" \
  --output files.zip

curl -X POST "http://localhost:8080/api/zip/extract" \
  -F "file=@files.zip"
```