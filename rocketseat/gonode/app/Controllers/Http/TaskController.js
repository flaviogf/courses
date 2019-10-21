'use strict'

const Task = use('App/Models/Task')

class TaskController {
  async index({ response }) {
    const tasks = await Task.all()

    return response.ok({ data: tasks, errors: [] })
  }

  async store({ request, response, auth }) {
    const { projectId, title, description, dueDate, fileId } = request.only([
      'projectId',
      'title',
      'description',
      'dueDate',
      'fileId'
    ])

    const user = await auth.getUser()

    const task = await Task.create({
      project_id: projectId,
      title,
      description,
      due_date: dueDate,
      user_id: user.id,
      file_id: fileId
    })

    return response.created({ data: task, errors: [] })
  }
}

module.exports = TaskController
