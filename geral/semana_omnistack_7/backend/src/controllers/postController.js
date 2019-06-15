const Post = require('../models/post')
const sharp = require('sharp')
const path = require('path')
const fs = require('fs')

module.exports = {
    async list(req, res) {
        const posts = await Post.find().sort('-createdAt')
        return res.json(posts)
    },
    async create(req, res) {
        const { author, place, description, hashtags } = req.body

        const { originalname, destination } = req.file

        const [name] = originalname.split('.')

        const image = `${name}.jpeg`

        await sharp(req.file.path)
            .resize(500)
            .toFormat('jpeg')
            .toFile(path.resolve(destination, 'resized', image))

        const post = await Post.create({
            author,
            place,
            description,
            hashtags,
            image,
        })

        fs.unlinkSync(req.file.path)

        return res.json(post)
    },
    async like(req, res) {
        const post = await Post.findById(req.params.id)

        post.likes += 1

        await post.save()

        return res.json(post)
    }
}