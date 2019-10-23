import { Router } from 'express'
import multer from 'multer'

import FileController from './app/controllers/FileController'
import SessionController from './app/controllers/SessionController'
import UserControler from './app/controllers/UserController'
import auth from './app/middlewares/auth'
import multerConfig from './config/multer'

const upload = multer(multerConfig)

const routes = Router()

routes.post('/session', SessionController.store)
routes.post('/user', UserControler.store)

routes.use(auth())

routes.put('/user', UserControler.update)

routes.post('/file', upload.single('file'), FileController.store)

module.exports = routes
