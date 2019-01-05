express = require 'express'

controller = require '../controllers/products'

router = express.Router()

router.get '/', controller.get
router.get '/:slug', controller.getBySlug
router.get '/admin/:id', controller.getById
router.get '/tags/:tag', controller.getByTag
router.post '/', controller.post
router.put '/:id', controller.put
router.delete '/:id', controller.delete

module.exports = router
