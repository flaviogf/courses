import File from '../models/File'
import User from '../models/User'

class ProviderController {
  async index(req, res) {
    const providers = await User.findAll({
      where: {
        provider: true
      },
      attributes: ['id', 'name', 'email', 'avatar_id'],
      include: [
        {
          model: File,
          as: 'avatar',
          attributes: ['name', 'path', 'url']
        }
      ]
    })

    return res.status(200).json({ data: providers, errors: [] })
  }
}

export default new ProviderController()
