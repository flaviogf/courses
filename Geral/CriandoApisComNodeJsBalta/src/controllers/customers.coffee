md5 = require 'md5'

repository = require '../repositories/customers'
emailService = require '../services/email'

exports.post = (req, res, next) ->
  try
    password = md5(password + process.env.KEY_SALT)
    customer = await repository.create {
      ...req.body
      password
    }
    emailService.send {
      to: customer.email
      subject: 'Bem vindo à Node Store'
      html: process.env.EMAIL_TEMPLATE.replace ///\{0\}///g, customer.name
    }
    res
      .status 200
      .send customer
  catch error
    console.log error
    res
      .status 400
      .send message: 'Falha ao cadastrar o cliente', data: error
