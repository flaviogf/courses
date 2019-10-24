import { promisify } from 'util'
import jwt from 'jsonwebtoken'
import authConfig from '../../config/auth'

function auth() {
  async function wrapper(req, res, next) {
    const { authorization = '' } = req.headers

    const [, token] = authorization.split(' ')

    try {
      const claims = await promisify(jwt.verify)(token, authConfig.secret)
      req.userId = claims.sub
      return next()
    } catch (error) {
      return res.status(401).json({ data: null, errors: ['Unauthorized'] })
    }
  }

  return wrapper
}

export default auth
