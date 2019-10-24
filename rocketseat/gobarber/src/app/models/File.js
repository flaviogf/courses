import { Model, DataTypes } from 'sequelize'

import appConfig from '../../config/app'

class File extends Model {
  static init(sequelize) {
    super.init(
      {
        name: DataTypes.STRING,
        path: DataTypes.STRING,
        url: {
          type: DataTypes.VIRTUAL,
          get() {
            return `${appConfig.url}/file/${this.path}`
          }
        }
      },
      {
        sequelize
      }
    )

    return this
  }
}

export default File
