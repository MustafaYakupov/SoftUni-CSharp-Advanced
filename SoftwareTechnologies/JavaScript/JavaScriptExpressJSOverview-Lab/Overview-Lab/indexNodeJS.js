const http = require('http');

http
    .createServer((req, res) => {
        res.write('Zdrasti!')
        res.end()
    })
    .listen(1337)