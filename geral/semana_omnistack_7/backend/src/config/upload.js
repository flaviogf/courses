const multer = require('multer')
const path = require('path')

const storage = new multer.diskStorage({
    destination(req, res, cb) {
        cb(null, path.resolve(__dirname, '..', '..', 'uploads'))
    }
})

const upload = multer({storage: storage})

module.exports = upload