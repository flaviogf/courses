import jwt from 'jsonwebtoken'
import { promisify } from 'util'
import User from '../models/User'
import authConfig from '../../config/auth'

class SessionController {
  async store(req, res) {
    const { email, password } = req.body

    const user = await User.findOne({
      where: {
        email
      }
    })

    if (!user || !(await user.checkPassword(password))) {
      return res
        .status(401)
        .json({ data: null, errors: 'Invalid email or password.' })
    }

    const token = await promisify(jwt.sign)(
      { sub: user.id },
      authConfig.secret,
      { expiresIn: authConfig.expiresIn }
    )

    return res.status(200).json({ data: token, errors: [] })
  }
}

export default new SessionController()
