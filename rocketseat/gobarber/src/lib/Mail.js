import { resolve } from 'path'
import nodemailer from 'nodemailer'
import expresshbs from 'express-handlebars'
import nodemailerhbs from 'nodemailer-express-handlebars'
import mailConfig from '../config/mail'

class Mail {
  constructor() {
    const { host, port, secure, auth } = mailConfig

    this.transport = nodemailer.createTransport({
      host,
      port,
      secure,
      auth
    })

    this.configureTemplate()
  }

  configureTemplate() {
    this.transport.use(
      'compile',
      nodemailerhbs({
        viewEngine: expresshbs.create({
          layoutsDir: resolve(__dirname, '..', 'views', 'emails', 'layouts'),
          partialsDir: resolve(__dirname, '..', 'views', 'emails', 'partials'),
          defaultLayout: 'default',
          extname: '.hbs'
        }),
        viewPath: resolve(__dirname, '..', 'views', 'emails'),
        extName: '.hbs'
      })
    )
  }

  send(message) {
    return this.transport.sendMail({
      ...mailConfig.default,
      ...message
    })
  }
}

export default new Mail()
