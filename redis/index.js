const express = require('express');
const axios = require('axios');
const redis = require('redis');

PORT = 3001;
const app = express();

app.get("/no-redis", async (req, res) => {
  try {
    console.time('LOG_TIME');
    
    axios({
      method: 'GET',
      url: 'https://jsonplaceholder.typicode.com/todos/1',
    }).then(async response => {
      const {userId} = response.data;
      console.timeEnd('LOG_TIME');
      return res.json({status: 200, userId});
    }).catch(async e => {
      console.log(e);
      return res.json({status: 500, message: 'error'});
    })
  } catch (e) {
    console.log('Get TODOs with an error: ', e);
  }
})

app.get("/with-redis", async (req, res) => {
  try {
    const client = redis.createClient();
    await client.connect();
    console.time('LOG_TIME');
    
    const uId = client.get('userId');
    if (uId) {
      console.timeEnd('LOG_TIME');
      return res.json({status: 200, userId: uId});
    }
    axios({
      method: 'GET',
      url: 'https://jsonplaceholder.typicode.com/todos/1',
    }).then(async response => {
      const {userId} = response.data;
      await client.set('userId', userId);
      console.timeEnd('LOG_TIME');
      return res.json({status: 200, userId});
    }).catch(async e => {
      console.log(e);
      return res.json({status: 500, message: 'error'});
    })
  } catch (e) {
    console.log('Get TODOs with an error: ', e);
  }
})

app.listen(PORT, (req, resp) => {
  console.log(`👨‍🎓 App is running at port 👉 `, PORT);
})