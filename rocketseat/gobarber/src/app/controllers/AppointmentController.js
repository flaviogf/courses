import * as Yup from 'yup'
import { startOfHour, parseISO, isBefore, format } from 'date-fns'
import pt from 'date-fns/locale/pt'
import Appointment from '../models/Appointment'
import File from '../models/File'
import User from '../models/User'
import Notification from '../schemas/Notification'

class AppointmentController {
  async index(req, res) {
    const { page } = req.query

    const appointments = await Appointment.findAll({
      where: {
        user_id: req.userId,
        canceled_at: null
      },
      order: ['date'],
      limit: 20,
      offset: (page - 1) * 20,
      attributes: ['id', 'date'],
      include: [
        {
          model: User,
          as: 'provider',
          attributes: ['id', 'name'],
          include: [
            {
              model: File,
              as: 'avatar',
              attributes: ['id', 'path', 'url']
            }
          ]
        }
      ]
    })

    return res.status(200).json({ data: appointments, errors: [] })
  }

  async store(req, res) {
    const schema = Yup.object().shape({
      provider_id: Yup.number()
        .integer()
        .required(),
      date: Yup.date().required()
    })

    if (!(await schema.isValid(req.body))) {
      return res
        .status(400)
        .json({ data: null, errors: ['Validations fails.'] })
    }

    const { provider_id, date } = req.body

    const checkProvider = await User.findOne({
      where: {
        id: provider_id,
        provider: true
      }
    })

    if (!checkProvider) {
      return res.status(400).json({
        data: null,
        errors: ['You can create appointment with only providers.']
      })
    }

    const hourStart = startOfHour(parseISO(date))

    if (isBefore(hourStart, new Date())) {
      return res
        .status(400)
        .json({ data: null, errors: ['Past dates are not permitted.'] })
    }

    const checkAvailability = await Appointment.findOne({
      where: {
        provider_id,
        canceled_at: null,
        date
      }
    })

    if (checkAvailability) {
      return res
        .status(400)
        .json({ data: null, errors: ['Appointment date is not available.'] })
    }

    const appointment = await Appointment.create({
      provider_id,
      date,
      user_id: req.userId
    })

    const user = await User.findByPk(req.userId)

    const formattedDate = format(
      hourStart,
      "'dia' dd 'de' MMMM', `as' H:mm'h'",
      { locale: pt }
    )

    await Notification.create({
      content: `Novo agendamento para ${user.name} no ${formattedDate}`,
      user: provider_id
    })

    return res.status(200).json({ data: appointment, errors: [] })
  }
}

export default new AppointmentController()
