Customer = require '../models/customers'

exports.create = (data) ->
  new Customer(data).save()
