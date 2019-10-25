import { Router } from 'express'
import multer from 'multer'

import AppointmentController from './app/controllers/AppointmentController'
import FileController from './app/controllers/FileController'
import ProviderController from './app/controllers/ProviderController'
import ScheduleController from './app/controllers/ScheduleController'
import SessionController from './app/controllers/SessionController'
import UserControler from './app/controllers/UserController'
import NotificationController from './app/controllers/NotificationController'

import auth from './app/middlewares/auth'
import multerConfig from './config/multer'

const upload = multer(multerConfig)

const routes = Router()

routes.post('/session', SessionController.store)
routes.post('/user', UserControler.store)

routes.use(auth())

routes.put('/user', UserControler.update)

routes.post('/file', upload.single('file'), FileController.store)

routes.get('/provider', ProviderController.index)

routes.get('/appointment', AppointmentController.index)
routes.post('/appointment', AppointmentController.store)
routes.delete('/appointment/:id', AppointmentController.delete)

routes.get('/schedule', ScheduleController.index)

routes.get('/notification', NotificationController.index)
routes.put('/notification/:id', NotificationController.update)

module.exports = routes
