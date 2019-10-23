import { Model, DataTypes } from 'sequelize'

class File extends Model {
  static init(sequelize) {
    super.init(
      {
        name: DataTypes.STRING,
        path: DataTypes.STRING
      },
      {
        sequelize
      }
    )

    return this
  }
}

export default File
