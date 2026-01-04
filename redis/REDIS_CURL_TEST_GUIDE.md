# 🧪 API Testing Guide (Using curl)

Base URL:
```
http://localhost:3000
```

---

## 1️⃣ Test Redis STRING (SET / GET)

### ➕ Set cache value
```bash
curl -X POST http://localhost:3000/cache   -H "Content-Type: application/json"   -d '{
    "key": "site:name",
    "value": "Redis Express Demo"
  }'
```

### 📥 Get cache value
```bash
curl http://localhost:3000/cache/site:name
```

Expected response:
```json
{
  "value": "Redis Express Demo"
}
```

---

## 2️⃣ Test Redis OBJECT (JSON)

### ➕ Save user object
```bash
curl -X POST http://localhost:3000/user   -H "Content-Type: application/json"   -d '{
    "id": 1,
    "name": "Phong Nguyen",
    "role": "admin"
  }'
```

### 📥 Get user by ID
```bash
curl http://localhost:3000/user/1
```

---

## 3️⃣ Test Redis COUNTER (INCR)

```bash
curl -X POST http://localhost:3000/view/home
```

---

## 4️⃣ Test Redis LIST (Log / Queue)

### ➕ Push log entry
```bash
curl -X POST http://localhost:3000/log   -H "Content-Type: application/json"   -d '{
    "event": "login",
    "user": "phong"
  }'
```

### 📥 Get latest logs
```bash
curl http://localhost:3000/log
```

---

## 5️⃣ Test Redis MULTIPLE KEYS (MGET)

```bash
curl http://localhost:3000/multi
```

---

## 6️⃣ Redis Debug Commands

```bash
redis-cli
KEYS *
TTL site:name
DEL site:name
```
