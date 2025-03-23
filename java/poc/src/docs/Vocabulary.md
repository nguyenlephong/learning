## Testing

```bash
curl -X GET http://localhost:8080/api/vocabulary

curl -X POST http://localhost:8080/api/vocabulary -H "Content-Type: application/json" -d '{
  "word": "hello",
  "meaning": "a greeting"
}'

curl -X PUT http://localhost:8080/api/vocabulary/hello -H "Content-Type: application/json" -d '{
  "word": "hello",
  "meaning": "a friendly greeting"
}'

curl -X DELETE http://localhost:8080/api/vocabulary/hello
```