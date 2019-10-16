'use strict'

const Project = use('App/Models/Project')

class ProjectController {
  async store({ request, response }) {
    const project = await Project.create(request.only(['title', 'description']))

    return response.created(project)
  }
}

module.exports = ProjectController
