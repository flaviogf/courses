'use strict'

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
}

module.exports = UserStore
