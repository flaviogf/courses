express = require 'express'

controller = require '../controllers/order'

router = express.Router()

router.post '/', controller.post
router.get '/', controller.get

module.exports = router
