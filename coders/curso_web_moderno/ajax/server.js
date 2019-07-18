const express = require('express')
const bodyParser = require('body-parser')
const multer = require('multer')

const app = express()

const storage = multer.diskStorage({
    destination(req, file, cb) {
        cb(null, './upload')
    },
    filename(req, file, cb) {
        cb(null, `${Date.now()}_${file.originalname}`)
    }
})

const upload = multer({
    storage
})

app.use(express.static('.'))

app.use(bodyParser.urlencoded({
    extended: true
}))

app.post('/upload', upload.single('file'))

app.post('/formulario', (req, res) => {
    res.json(req.body)
})

app.listen(3000, () => console.log('|> Running on port 3000'))