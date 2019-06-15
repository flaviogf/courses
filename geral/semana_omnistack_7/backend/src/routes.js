const express = require('express')
const upload = require('./config/upload')

const router = new express.Router()

const postController = require('./controllers/postController')

router.get('/posts', postController.list)
router.post('/posts', upload.single('image'), postController.create)
router.post('/posts/:id/like', postController.like)

module.exports = router