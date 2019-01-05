Order = require '../models/order'

exports.create = (data) ->
  new Order(data).save()

exports.get = () ->
  Order
    .find {}, 'number customer items'
    .populate 'customer', 'name'
    .populate 'items.product', 'title'
