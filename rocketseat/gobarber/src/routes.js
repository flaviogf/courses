import { Router } from 'express'

import User from './app/models/User'

const routes = Router()

routes.get('/', async (req, res) => {
  const user = await User.create({
    name: 'flavio',
    email: 'flavio@smn.com.br',
    password_hash: 'xpto'
  })

  return res.json(user)
})

module.exports = routes
