const port = 3003;

const bodyParser = require('body-parser');
const cors = require('./cors');
const express = require('express');
const server = express();

server.use(bodyParser.urlencoded({ extended: true }));
server.use(bodyParser.json());
server.use(cors);

server.listen(port, () => {
  console.log(`BACKEND rodando na porta ${port}`);
});

module.exports = server;
