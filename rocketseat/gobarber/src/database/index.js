import Sequelize from 'sequelize'
import mongoose from 'mongoose'

import databaseConfig from '../config/database'

import Appointment from '../app/models/Appointment'
import File from '../app/models/File'
import User from '../app/models/User'

const models = [Appointment, File, User]

class Database {
  constructor() {
    this.sequelize = new Sequelize(databaseConfig)

    this.init()
    this.mongo()
  }

  init() {
    models
      .map((it) => it.init(this.sequelize))
      .map((it) => it.associate && it.associate(this.sequelize.models))
  }

  mongo() {
    this.mongoConnection = mongoose.connect(
      'mongodb://localhost:27017/gobarber',
      { useNewUrlParser: true, useUnifiedTopology: true }
    )
  }
}

export default new Database()
