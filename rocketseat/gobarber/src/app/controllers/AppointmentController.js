import * as Yup from 'yup'
import { startOfHour, parseISO, isBefore, format, subHours } from 'date-fns'
import pt from 'date-fns/locale/pt'
import Appointment from '../models/Appointment'
import File from '../models/File'
import User from '../models/User'
import Notification from '../schemas/Notification'
import Mail from '../../lib/Mail'

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

  async delete(req, res) {
    const { id } = req.params

    const appointment = await Appointment.findOne({
      where: {
        id
      },
      include: [
        {
          model: User,
          as: 'provider',
          attributes: ['name', 'email']
        },
        {
          model: User,
          as: 'user',
          attributes: ['name']
        }
      ]
    })

    if (appointment.user_id !== req.userId) {
      return res.status(403).json({
        data: null,
        errors: ['You dont have permission to cancel this appointment']
      })
    }

    const dateMinusTwoHours = subHours(appointment.date, 2)

    if (isBefore(dateMinusTwoHours, new Date())) {
      return res.status(400).json({
        data: null,
        errors: 'You can only cancel appointments 2 hours in advance.'
      })
    }

    appointment.canceled_at = new Date()

    await appointment.save()

    await Mail.send({
      to: appointment.provider.email,
      subject: 'Agendamento cancelado',
      template: 'cancellation-appointment',
      context: {
        provider: appointment.provider.name,
        user: appointment.user.name,
        date: format(appointment.date, "'dia' dd 'de' MMMM', `as' HH:mm'h'", {
          locale: pt
        })
      }
    })

    return res.status(200).json({ data: null, errors: [] })
  }
}

export default new AppointmentController()
