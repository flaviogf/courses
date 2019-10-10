'use strict'

const User = use('App/Models/User')

class UserController {
  async store({ request, response }) {
    const user = await User.create(request.only(['email', 'password']))

    return response.created({ data: user, errors: [] })
  }
}

module.exports = UserController
