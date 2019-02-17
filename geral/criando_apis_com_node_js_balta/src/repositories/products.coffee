Product = require '../models/products'

exports.get = () ->
  Product.find active: yes, 'title slug price'

exports.getBySlug = (slug) ->
  Product.findOne {
    slug
    active: yes
  },
  'title slug price'

exports.getById = (id) ->
  Product.findById id, 'title slug price'

exports.getByTag = (tag) ->
  Product.find {
    tags: tag
  },
  'title slug price'

exports.create = (data) ->
  new Product(data).save()

exports.update = (id, { title, description, price, slug }) ->
  update = $set: {
    title
    description
    price
    slug
  }
  Product.findByIdAndUpdate id, update, new: yes

exports.delete = (id) ->
  Product.findByIdAndRemove id
