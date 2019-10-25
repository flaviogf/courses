import nodemailer from 'nodemailer'
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
  }

  send(message) {
    return this.transport.sendMail({
      ...mailConfig.default,
      ...message
    })
  }
}

export default new Mail()
