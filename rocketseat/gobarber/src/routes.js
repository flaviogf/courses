import { Router } from 'express'

import SessionController from './app/controllers/SessionController'
import UserControler from './app/controllers/UserController'
import auth from './app/middlewares/auth'

const routes = Router()

routes.post('/session', SessionController.store)
routes.post('/user', UserControler.store)

routes.use(auth())

routes.put('/user', UserControler.update)

module.exports = routes
