'use strict'

const { test, trait } = use('Test/Suite')('Fogot Password')

const Mail = use('Mail')
const User = use('App/Models/User')

const chance = require('chance').Chance()

trait('DatabaseTransactions')
trait('Test/ApiClient')

test('should return status 200 when restore password is requested', async ({
  assert,
  client
}) => {
  Mail.fake()

  const user = await User.create({
    email: chance.email(),
    password: chance.word()
  })

  const data = {
    email: user.email
  }

  const response = await client
    .post('/forgot-password')
    .send(data)
    .end()

  response.assertStatus(200)

  assert.lengthOf(Mail.all(), 1)

  Mail.restore()
})
