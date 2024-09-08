const express = require('express');
const data = require('./data');
const app = express()

app.get('/', (req, res) => {
    res.send(data.hello)
})

app.get('/cats', (req, res) => {
    res.send(data.cats)
})

app.listen(1337)

console.log('Server listenning on port 1337...')