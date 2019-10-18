'use strict'

const { test, trait } = use('Test/Suite')('Project')

const Factory = use('Factory')
const Project = use('App/Models/Project')

const chance = require('chance').Chance()

trait('DatabaseTransactions')
trait('Test/ApiClient')
trait('Auth/Client')

test('should return status 201 when project is created', async ({ client }) => {
  const user = await Factory.model('App/Models/User').create()

  const data = {
    title: chance.word(),
    description: chance.word()
  }

  const response = await client
    .post('/project')
    .loginVia(user)
    .send(data)
    .end()

  response.assertStatus(201)
})

test('should update database when project is created', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const data = {
    title: chance.word(),
    description: chance.word()
  }

  await client
    .post('/project')
    .loginVia(user)
    .send(data)
    .end()

  const count = await Project.getCount()

  const project = await Project.first()

  assert.equal(count, 1)
  assert.equal(project.title, data.title)
  assert.equal(project.description, data.description)
  assert.equal(project.user_id, user.id)
})

test('should return status 200 when projects are listed', async ({
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const response = await client
    .get('/project')
    .loginVia(user)
    .end()

  response.assertStatus(200)
})

test('should return a list of project when projects are listed', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const response = await client
    .get('/project')
    .loginVia(user)
    .end()

  const { data } = response.body

  assert.lengthOf(data, 1)
  assert.equal(data[0].title, project.title)
  assert.equal(data[0].description, project.description)
})

test('should return status 200 when project exist', async ({ client }) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const response = await client
    .get(`/project/${project.id}`)
    .loginVia(user)
    .end()

  response.assertStatus(200)
})

test('should return a project when project exist', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const response = await client
    .get(`/project/${project.id}`)
    .loginVia(user)
    .end()

  const { data } = response.body

  assert.equal(data.title, project.title)
  assert.equal(data.description, project.description)
})

test('should return status 200 when project is updated', async ({ client }) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const data = {
    title: chance.word(),
    description: chance.word()
  }

  const response = await client
    .put(`/project/${project.id}`)
    .loginVia(user)
    .send(data)
    .end()

  response.assertStatus(200)
})

test('should update project when project is updated', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const data = {
    title: chance.word(),
    description: chance.word()
  }

  await client
    .put(`/project/${project.id}`)
    .loginVia(user)
    .send(data)
    .end()

  await project.reload()

  assert.equal(project.title, data.title)
  assert.equal(project.description, data.description)
})

test('should return status 200 when project is destroyed', async ({
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  const response = await client
    .delete(`/project/${project.id}`)
    .loginVia(user)
    .end()

  response.assertStatus(200)
})

test('should destroy project when project is destroyed', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Project.create({
    title: chance.word(),
    description: chance.word()
  })

  await client
    .delete(`/project/${project.id}`)
    .loginVia(user)
    .end()

  const count = await Project.getCount()

  assert.equal(count, 0)
})
