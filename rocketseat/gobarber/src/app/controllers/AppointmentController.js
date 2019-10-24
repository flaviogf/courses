import * as Yup from 'yup'
import Appointment from '../models/Appointment'
import User from '../models/User'

class AppointmentController {
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

    const appointment = await Appointment.create({
      provider_id,
      date,
      user_id: req.userId
    })

    return res.status(200).json({ data: appointment, errors: [] })
  }
}

export default new AppointmentController()
