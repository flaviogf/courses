'use strict'

const Project = use('App/Models/Project')

class ProjectController {
  async index({ response }) {
    const projects = await Project.all()

    return response.ok({ data: projects, errors: [] })
  }

  async store({ request, response, auth }) {
    const { title, description } = request.only(['title', 'description'])

    const user = await auth.getUser()

    const project = await Project.create({
      title,
      description,
      user_id: user.id
    })

    return response.created({ data: project, errros: [] })
  }

  async show({ params, response }) {
    const { id } = params

    const project = await Project.findOrFail(id)

    return response.ok({ data: project, errors: [] })
  }

  async update({ params, request, response }) {
    const { id } = params

    const project = await Project.findOrFail(id)

    project.merge(request.only(['title', 'description']))

    await project.save()

    return response.ok({ data: null, errors: [] })
  }

  async destroy({ params, response }) {
    const { id } = params

    const project = await Project.findOrFail(id)

    await project.delete()

    return response.ok({ data: null, errors: [] })
  }
}

module.exports = ProjectController
