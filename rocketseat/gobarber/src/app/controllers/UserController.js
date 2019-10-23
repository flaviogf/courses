import * as Yup from 'yup'
import User from '../models/User'

class UserController {
  async store(req, res) {
    const schema = Yup.object().shape({
      name: Yup.string().required(),
      email: Yup.string()
        .required()
        .email(),
      password: Yup.string().required(),
      provider: Yup.boolean().required()
    })

    if (!(await schema.isValid(req.body))) {
      return res.status(400).json({ data: null, errors: ['Validation fails.'] })
    }

    const emailExist = await User.findOne({
      where: {
        email: req.body.email
      }
    })

    if (emailExist) {
      return res
        .status(400)
        .json({ data: null, errors: ['Email already in use.'] })
    }

    const { id, name, email, provider } = await User.create(req.body)

    return res
      .status(201)
      .json({ data: { id, name, email, provider }, errors: [] })
  }

  async update(req, res) {
    const schema = Yup.object().shape({
      name: Yup.string(),
      email: Yup.string().email(),
      oldPassword: Yup.string().when('password', (password, field) => {
        return password ? field.required() : field
      }),
      password: Yup.string(),
      confirmPassword: Yup.string().when('password', (password, field) => {
        return password ? field.required().oneOf([password]) : field
      }),
      provider: Yup.boolean()
    })

    if (!(await schema.isValid(req.body))) {
      return res.status(400).json({ data: null, errors: ['Validation fails.'] })
    }

    const { email, oldPassword } = req.body

    const user = await User.findByPk(req.userId)

    if (email !== user.email && User.findOne({ where: { email } })) {
      return res
        .status(400)
        .json({ data: null, errors: ['Email already in use.'] })
    }

    if (oldPassword && !(await user.checkPassword(oldPassword))) {
      return res
        .status(400)
        .json({ data: null, errors: ['Old password does not match.'] })
    }

    const { id, name, provider } = await user.update(req.body)

    return res
      .status(200)
      .json({ data: { id, name, email, provider }, errors: [] })
  }
}

export default new UserController()
