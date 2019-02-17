express = require 'express'

controller = require '../controllers'

router = express.Router()

router.get '/', controller.get

module.exports = router
