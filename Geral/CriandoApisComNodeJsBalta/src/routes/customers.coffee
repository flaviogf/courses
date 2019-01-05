express = require 'express'

controller = require '../controllers/customers'

router = express.Router()

router.post '/', controller.post

module.exports = router
