import { Model, DataTypes } from 'sequelize'
import { isBefore, subHours } from 'date-fns'

class Appointment extends Model {
  static init(sequelize) {
    super.init(
      {
        date: DataTypes.DATE,
        canceled_at: DataTypes.DATE,
        past: {
          type: DataTypes.VIRTUAL,
          get() {
            return isBefore(this.date, new Date())
          }
        },
        cancelable: {
          type: DataTypes.VIRTUAL,
          get() {
            return isBefore(subHours(new Date(), 2), this.date)
          }
        }
      },
      {
        sequelize
      }
    )

    return this
  }

  static associate(models) {
    this.belongsTo(models.User, {
      foreignKey: 'user_id',
      as: 'user'
    })

    this.belongsTo(models.User, {
      foreignKey: 'provider_id',
      as: 'provider'
    })

    return this
  }
}

export default Appointment
