import { Op } from 'sequelize'
import { startOfDay, endOfDay, parseISO } from 'date-fns'
import Appointment from '../models/Appointment'
import User from '../models/User'

class ScheduleController {
  async index(req, res) {
    const { date } = req.query

    const checkUserProvider = await User.findOne({
      where: {
        id: req.userId,
        provider: true
      }
    })

    if (!checkUserProvider) {
      return res
        .status(403)
        .json({ data: null, errors: ['User not is provider.'] })
    }

    const parsedDate = parseISO(date)

    const appointments = await Appointment.findAll({
      where: {
        provider_id: req.userId,
        canceled_at: null,
        date: {
          [Op.between]: [startOfDay(parsedDate), endOfDay(parsedDate)]
        }
      },
      order: ['date']
    })

    return res.status(200).json({ data: appointments, errors: [] })
  }
}

export default new ScheduleController()
