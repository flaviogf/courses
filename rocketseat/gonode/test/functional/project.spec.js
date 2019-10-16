'use strict'

const { test, trait } = use('Test/Suite')('Project')

const Project = use('App/Models/Project')

const chance = require('chance').Chance()

trait('DatabaseTransactions')
trait('Test/ApiClient')

test('should return status 201 when project is created', async ({ client }) => {
  const data = {
    title: chance.word(),
    description: chance.word()
  }

  const response = await client
    .post('/project')
    .send(data)
    .end()

  response.assertStatus(201)
})

test('should update database when project is created', async ({
  assert,
  client
}) => {
  const data = {
    title: chance.word(),
    description: chance.word()
  }

  await client
    .post('/project')
    .send(data)
    .end()

  const count = await Project.getCount()

  const project = await Project.first()

  assert.equal(count, 1)
  assert.equal(project.title, data.title)
  assert.equal(project.description, data.description)
})
