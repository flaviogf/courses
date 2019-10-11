'use strict'

const Env = use('Env')
const Mail = use('Mail')
const User = use('App/Models/User')

const crypto = require('crypto')
const ms = require('ms')

class ForgotPasswordController {
  async store({ request, response }) {
    const email = request.input('email')

    const user = await User.findBy('email', email)

    const token = crypto.randomBytes(8).toString('hex')

    user.token = token
    user.token_expired_date = ms('1m')

    await user.save()

    const link = `${Env.get('APP_URL')}/?token=${token}`

    await Mail.send(
      'emails.forgot-password',
      { email: user.email, link },
      (message) => {
        message
          .to(user.email)
          .from('no-reply@flaviogf.com.br')
          .subject('Request restore password.')
      }
    )

    return response.ok(user)
  }
}

module.exports = ForgotPasswordController
