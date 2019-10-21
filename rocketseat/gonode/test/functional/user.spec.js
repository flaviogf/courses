'use strict'

const { test, trait } = use('Test/Suite')('User')

const User = use('App/Models/User')
const Hash = use('Hash')

const chance = require('chance').Chance()

trait('DatabaseTransactions')
trait('Test/ApiClient')

test('should return status 201 when user is created', async ({ client }) => {
  const data = {
    email: chance.email(),
    password: chance.word()
  }

  const response = await client
    .post('/user')
    .send(data)
    .end()

  response.assertStatus(201)
})

test('should update database when user is created', async ({
  assert,
  client
}) => {
  const data = {
    email: chance.email(),
    password: chance.word()
  }

  await client
    .post('/user')
    .send(data)
    .end()

  const count = await User.getCount()

  const user = await User.first()

  assert.equal(count, 1)
  assert.equal(user.email, data.email)
  assert.isTrue(await Hash.verify(data.password, user.password))
})

test('should return status 400 when request is invalid', async ({ client }) => {
  const data = {
    email: chance.word(),
    password: chance.word()
  }

  const response = await client
    .post('/user')
    .send(data)
    .end()

  response.assertStatus(400)
})
