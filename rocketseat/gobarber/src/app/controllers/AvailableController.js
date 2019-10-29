import { Op } from 'sequelize'
import {
  startOfDay,
  endOfDay,
  setSeconds,
  setMinutes,
  setHours,
  format,
  isAfter
} from 'date-fns'
import Appointment from '../models/Appointment'

class AvailableController {
  async index(req, res) {
    const { id } = req.params

    const searchDate = Number(req.query.date)

    const appointments = await Appointment.findAll({
      where: {
        provider_id: id,
        canceled_at: null,
        date: {
          [Op.between]: [startOfDay(searchDate), endOfDay(searchDate)]
        }
      }
    })

    const schedules = [
      '08:00',
      '09:00',
      '10:00',
      '11:00',
      '12:00',
      '13:00',
      '14:00',
      '15:00',
      '16:00',
      '17:00',
      '18:00',
      '19:00'
    ]

    const availables = schedules.map((time) => {
      const [hour, minutes] = time.split(':')
      const date = setSeconds(
        setMinutes(setHours(searchDate, hour), minutes),
        0
      )
      return {
        time,
        date: format(date, "yyyy-MM-dd'T'HH:mm:ssxxx"),
        available:
          isAfter(date, searchDate) &&
          !appointments.find((it) => format(it.date, 'HH:mm') === time)
      }
    })

    return res.status(200).json({ data: availables, errors: [] })
  }
}

export default new AvailableController()
