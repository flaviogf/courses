import path from 'path'
import Youch from 'youch'
import express from 'express'

import 'express-async-errors'
import routes from './routes'

import './database'

class App {
  constructor() {
    this.server = express()

    this.middlewares()
    this.routes()
    this.exceptionHandler()
  }

  middlewares() {
    this.server.use(express.json())
    this.server.use(
      '/file',
      express.static(path.resolve(__dirname, '..', 'tmp', 'upload'))
    )
  }

  routes() {
    this.server.use(routes)
  }

  exceptionHandler() {
    this.server.use(async (err, req, res, next) => {
      const error = await new Youch(err, req).toJSON()
      res.status(500).json({ data: null, errors: [error] })
    })
  }
}

export default new App().server
