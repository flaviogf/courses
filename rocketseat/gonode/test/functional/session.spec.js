'use strict'

const { test, trait } = use('Test/Suite')('Session')

const chance = require('chance').Chance()

const User = use('App/Models/User')

trait('DatabaseTransactions')
trait('Test/ApiClient')

test('should return status 200 when user is authenticated', async ({
  client
}) => {
  const email = chance.email()
  const password = chance.word()

  await User.create({ email, password })

  const data = { email, password }

  const response = await client
    .post('/session')
    .send(data)
    .end()

  response.assertStatus(200)
})

test('should return a jwt token when user is authenticated', async ({
  assert,
  client
}) => {
  const email = chance.email()
  const password = chance.word()

  await User.create({ email, password })

  const data = { email, password }

  const response = await client
    .post('/session')
    .send(data)
    .end()

  assert.isOk(response.body.data)
})
