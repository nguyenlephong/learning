const express = require('express');
const redis = require('./redis');

const app = express();
app.use(express.json());

/**
 * 1️⃣ SET / GET STRING (cache đơn giản)
 */
app.post('/cache', async (req, res) => {
  const { key, value } = req.body;
  await redis.set(key, value, { EX: 60 }); // TTL 60s
  res.json({ message: 'Cached successfully' });
});

app.get('/cache/:key', async (req, res) => {
  const value = await redis.get(req.params.key);
  res.json({ value });
});

/**
 * 2️⃣ SET / GET OBJECT (JSON)
 */
app.post('/user', async (req, res) => {
  const user = req.body;
  await redis.set(
    `user:${user.id}`,
    JSON.stringify(user),
    { EX: 300 }
  );
  res.json({ message: 'User saved to redis' });
});

app.get('/user/:id', async (req, res) => {
  const data = await redis.get(`user:${req.params.id}`);
  res.json(JSON.parse(data));
});

/**
 * 3️⃣ COUNTER (INCR)
 */
app.post('/view/:page', async (req, res) => {
  const views = await redis.incr(`page:view:${req.params.page}`);
  res.json({ page: req.params.page, views });
});

/**
 * 4️⃣ LIST (queue / history)
 */
app.post('/log', async (req, res) => {
  await redis.lPush('logs', JSON.stringify(req.body));
  await redis.lTrim('logs', 0, 9); // chỉ giữ 10 log gần nhất
  res.json({ message: 'Log added' });
});

app.get('/log', async (req, res) => {
  const logs = await redis.lRange('logs', 0, -1);
  res.json(logs.map(l => JSON.parse(l)));
});

/**
 * 5️⃣ MULTIPLE KEYS (MGET)
 */
app.get('/multi', async (req, res) => {
  const values = await redis.mGet([
    'site:name',
    'site:version',
    'site:status'
  ]);
  res.json(values);
});

app.listen(3000, () => {
  console.log('API running at http://localhost:3000');
});