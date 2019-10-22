import Sequelize from 'sequelize'

import databaseConfig from '../config/database'

import User from '../app/models/User'

const models = [User]

class Database {
  constructor() {
    this.sequelize = new Sequelize(databaseConfig)

    this.init()
  }

  init() {
    models.map((it) => it.init(this.sequelize))
  }
}

export default new Database()
