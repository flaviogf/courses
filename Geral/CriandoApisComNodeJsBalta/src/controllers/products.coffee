repository = require '../repositories/products'

exports.get = (req, res, next) ->
  products = await repository.get()
  res
    .status 200
    .send products

exports.getBySlug = (req, res, next) ->
  products = await repository.getBySlug req.params.slug
  res
    .status 200
    .send products

exports.getById = (req, res, next) ->
  products = await repository.getById req.params.id
  res
    .status 200
    .send products

exports.getByTag = (req, res, next) ->
  products = await repository.getByTag req.params.tag
  res
    .status 200
    .send products

exports.post = (req, res, next) ->
  try
    await repository.create req.body
    res
      .status 201
      .send message: 'Produto cadastrado com sucesso'
  catch error
    res
      .status 400
      .send message: 'Falha ao cadastrar o produto', data: error

exports.put = (req, res, next) ->
  try
    product = await repository.update req.params.id, req.body
    res
      .status 200
      .send id: req.params.id, item: product
  catch error
    res
      .status 400
      .send message: 'Falha ao atualizar o produto', data: error

exports.delete = (req, res, next) ->
  try
    product = await repository.delete req.params.id
    res
      .status 200
      .send id: req.params.id, item: product
  catch error
    res
      .status 400
      .send message: 'Falha ao remover o produto', data: error
