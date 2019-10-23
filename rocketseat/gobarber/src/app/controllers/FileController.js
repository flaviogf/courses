import File from '../models/File'

class FileController {
  async store(req, res) {
    const { originalname: name, filename: path } = req.file

    const file = await File.create({
      name,
      path
    })

    return res.status(201).json({ data: file, errors: [] })
  }
}

export default new FileController()
