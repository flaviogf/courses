guid = require 'guid'

repository = require '../repositories/order'

exports.post = (req, res, next) ->
  try
    number = guid.raw().substring(0, 6)
    order = await repository.create {
      ...req.body
      number
    }
    res
      .status 200
      .send order
  catch error
    res
      .status 400
      .send message: 'Falha ao cadastrar o pedido', data: error

exports.get = (req, res, next) ->
  orders = await repository.get()
  res
    .status 200
    .send orders
