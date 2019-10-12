'use strict'

const { test, trait } = use('Test/Suite')('Fogot Password')

const Hash = use('Hash')
const Mail = use('Mail')
const User = use('App/Models/User')

const crypto = require('crypto')
const chance = require('chance').Chance()
const { subDays, getTime } = require('date-fns')

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

test('should return status 200 when password is changed', async ({
  client
}) => {
  const token = crypto.randomBytes(8).toString('hex')
  const tokenCreatedAt = getTime(new Date())

  await User.create({
    email: chance.email(),
    password: chance.word(),
    token,
    token_created_at: tokenCreatedAt
  })

  const data = {
    token,
    password: chance.word()
  }

  const response = await client
    .put('/forgot-password')
    .send(data)
    .end()

  response.assertStatus(200)
})

test('should update database when password is changed', async ({
  assert,
  client
}) => {
  const token = crypto.randomBytes(8).toString('hex')
  const tokenCreatedAt = getTime(new Date())

  const user = await User.create({
    email: chance.email(),
    password: chance.word(),
    token,
    token_created_at: tokenCreatedAt
  })

  const data = {
    token,
    password: chance.word()
  }

  await client
    .put('/forgot-password')
    .send(data)
    .end()

  await user.reload()

  assert.isTrue(await Hash.verify(data.password, user.password))
})

test('should return status 400 when token is expired', async ({
  assert,
  client
}) => {
  const token = crypto.randomBytes(8).toString('hex')
  const tokenCreatedAt = getTime(subDays(new Date(), 3))

  await User.create({
    email: chance.email(),
    password: chance.word(),
    token,
    token_created_at: tokenCreatedAt
  })

  const data = {
    token,
    password: chance.word()
  }

  const response = await client
    .put('/forgot-password')
    .send(data)
    .end()

  response.assertStatus(400)
})
