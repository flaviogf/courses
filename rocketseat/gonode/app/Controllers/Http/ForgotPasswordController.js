'use strict'

const Env = use('Env')
const Mail = use('Mail')
const User = use('App/Models/User')

const crypto = require('crypto')
const { getTime, isAfter, subDays } = require('date-fns')

class ForgotPasswordController {
  async store({ request, response }) {
    const email = request.input('email')

    const user = await User.findBy('email', email)

    const token = crypto.randomBytes(8).toString('hex')

    user.token = token
    user.token_created_at = getTime(new Date())

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

  async update({ request, response }) {
    const { token, password } = request.only(['token', 'password'])

    const user = await User.findBy('token', token)

    if (isAfter(subDays(new Date(), 2), user.token_created_at)) {
      return response.badRequest({ data: null, errors: ['Token is expired.'] })
    }

    user.password = password

    await user.save()

    return response.ok({ data: null, errors: [] })
  }
}

module.exports = ForgotPasswordController
