import User from '../models/User'
import Notification from '../schemas/Notification'

class NotificationController {
  async index(req, res) {
    const checkIsProvider = await User.findOne({
      where: {
        id: req.userId,
        provider: true
      }
    })

    if (!checkIsProvider) {
      return res.status(403).json({
        data: null,
        errors: ['Only providers can load notifications.']
      })
    }

    const notifications = await Notification.find({
      user: req.userId
    })
      .sort('-createdAt')
      .limit(20)

    return res.status(200).json({ data: notifications, errors: [] })
  }

  async update(req, res) {
    const { id } = req.params

    const notification = await Notification.findById(id)

    notification.read = true

    await notification.save()

    return res.status(200).json({ data: null, errors: [] })
  }
}

export default new NotificationController()
