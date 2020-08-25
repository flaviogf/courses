import { Router } from 'express'

const routes = Router()

routes.post('/', (req, res) => {
  const { email, password } = req.body

  const user = {
    email,
    password,
  }

  return res.json(user)
})

routes.get('/', (req, res) => {
  return res.json({ ok: true })
})

export default routes
