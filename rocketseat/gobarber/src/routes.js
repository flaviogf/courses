import { Router } from 'express'

import UserControler from './app/controllers/UserController'

const routes = Router()

routes.post('/user', UserControler.store)

module.exports = routes
