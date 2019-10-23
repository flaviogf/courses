import Sequelize from 'sequelize'

import databaseConfig from '../config/database'

import File from '../app/models/File'
import User from '../app/models/User'

const models = [File, User]

class Database {
  constructor() {
    this.sequelize = new Sequelize(databaseConfig)

    this.init()
  }

  init() {
    models
      .map((it) => it.init(this.sequelize))
      .map((it) => it.associate && it.associate(this.sequelize.models))
  }
}

export default new Database()
