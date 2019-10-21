'use strict'

const { test, trait } = use('Test/Suite')('Task')

const Factory = use('Factory')
const Task = use('App/Models/Task')

const chance = require('chance').Chance()

trait('DatabaseTransactions')
trait('Test/ApiClient')
trait('Auth/Client')

test('should return status 201 when task is created', async ({ client }) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Factory.model('App/Models/Project').create({
    user_id: user.id
  })

  const file = await Factory.model('App/Models/File').create()

  const data = {
    projectId: project.id,
    title: chance.word(),
    description: chance.word(),
    dueDate: chance.date().toISOString(),
    fileId: file.id
  }

  const response = await client
    .post('/task')
    .loginVia(user)
    .send(data)
    .end()

  response.assertStatus(201)
})

test('should add task to database when task is created', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Factory.model('App/Models/Project').create({
    user_id: user.id
  })

  const file = await Factory.model('App/Models/File').create()

  const data = {
    projectId: project.id,
    title: chance.word(),
    description: chance.word(),
    dueDate: chance.date().toISOString(),
    fileId: file.id
  }

  await client
    .post('/task')
    .loginVia(user)
    .send(data)
    .end()

  const count = await Task.getCount()

  const task = await Task.first()

  assert.equal(count, 1)
  assert.equal(task.project_id, data.projectId)
  assert.equal(task.title, data.title)
  assert.equal(task.description, data.description)
  assert.equal(task.due_date, data.dueDate)
  assert.equal(task.user_id, user.id)
  assert.equal(task.file_id, file.id)
})

test('should return status 200 when tasks are listed', async ({ client }) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Factory.model('App/Models/Project').create({
    user_id: user.id
  })

  const file = await Factory.model('App/Models/File').create()

  await Factory.model('App/Models/Task').create({
    user_id: user.id,
    project_id: project.id,
    file_id: file.id
  })

  const response = await client
    .get('/task')
    .loginVia(user)
    .end()

  response.assertStatus(200)
})

test('should return a list of task when taks are listed', async ({
  assert,
  client
}) => {
  const user = await Factory.model('App/Models/User').create()

  const project = await Factory.model('App/Models/Project').create({
    user_id: user.id
  })

  const file = await Factory.model('App/Models/File').create()

  const task = await Factory.model('App/Models/Task').create({
    user_id: user.id,
    project_id: project.id,
    file_id: file.id
  })

  const response = await client
    .get('/task')
    .loginVia(user)
    .end()

  const { data } = response.body

  assert.lengthOf(data, 1)
  assert.equal(data[0].id, task.id)
  assert.equal(data[0].user_id, task.user_id)
  assert.equal(data[0].project_id, task.project_id)
  assert.equal(data[0].file_id, task.file_id)
  assert.equal(data[0].title, task.title)
  assert.equal(data[0].description, task.description)
  assert.equal(
    new Date(data[0].due_date).toISOString(),
    task.due_date.toISOString()
  )
})
