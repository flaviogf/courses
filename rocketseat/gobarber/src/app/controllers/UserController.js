import User from '../models/User'

class UserController {
  async store(req, res) {
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

    const user = await User.create(req.body)

    return res.status(201).json({ data: user, errors: [] })
  }
}

export default new UserController()
