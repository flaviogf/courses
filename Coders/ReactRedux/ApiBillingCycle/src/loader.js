const server = require('./config/server');
require('./config/database');
require('./config/router')(server);
