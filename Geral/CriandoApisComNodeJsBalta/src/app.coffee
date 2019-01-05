express = require 'express'
bodyParser = require 'body-parser'
mongoose = require 'mongoose'

app = express()

app.use bodyParser.json()
app.use bodyParser.urlencoded extended: yes

mongoose
  .connect process.env.MONGO_URL, useNewUrlParser: yes, useCreateIndex: yes

require './models/products'
require './models/customers'
require './models/order'

app.use '/', require './routes'
app.use '/products', require './routes/products'
app.use '/customers', require './routes/customers'
app.use '/orders', require './routes/order'

module.exports = app
