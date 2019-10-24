import crypto from 'crypto'
import path from 'path'
import multer from 'multer'

export default {
  storage: multer.diskStorage({
    destination(req, file, cb) {
      const destination = path.resolve(__dirname, '..', '..', 'tmp', 'upload')
      cb(null, destination)
    },
    filename(req, file, cb) {
      const name = crypto.randomBytes(8).toString('hex')
      const ext = path.extname(file.originalname)
      const filename = `${name}${ext}`
      cb(null, filename)
    }
  })
}
