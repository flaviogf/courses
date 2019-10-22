'use strict'

const Antl = use('Antl')

class UserStore {
  get validateAll() {
    return true
  }

  get rules() {
    return {
      email: 'required|unique:users|email',
      password: 'required'
    }
  }

  get messages() {
    return Antl.list('validations')
  }
}

module.exports = UserStore
