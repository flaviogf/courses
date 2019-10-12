'use strict'

const Helpers = use('Helpers')
const File = use('App/Models/File')

class FileController {
  async store({ request, response }) {
    const requestFile = request.file('file', { size: '2mb' })

    const filename = `${Date.now()}-${requestFile.clientName}`

    await requestFile.move(Helpers.tmpPath('uploads'), {
      name: filename
    })

    const file = await File.create({
      file: filename,
      name: requestFile.clientName,
      type: requestFile.type,
      subtype: requestFile.subtype
    })

    return response.created({ data: file.id, errors: [] })
  }

  async show({ params, response }) {
    const { id } = params

    const file = await File.find(id)

    return response.download(Helpers.tmpPath(`uploads/${file.file}`), file.name)
  }
}

module.exports = FileController
