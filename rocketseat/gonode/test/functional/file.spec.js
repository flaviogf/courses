'use strict'

const { test, trait } = use('Test/Suite')('File')

const Helpers = use('Helpers')
const File = use('App/Models/File')

trait('DatabaseTransactions')
trait('Test/ApiClient')

test('should return status 201 when upload file successfully', async ({
  client
}) => {
  const response = await client
    .post('/file')
    .attach('file', Helpers.tmpPath('uploads/fixture.png'))
    .end()

  response.assertStatus(201)
})

test('should update database when upload file successfully', async ({
  assert,
  client
}) => {
  await client
    .post('/file')
    .attach('file', Helpers.tmpPath('uploads/fixture.png'))
    .end()

  const count = await File.getCount()

  assert.equal(1, count)
})

test('should status 200 when request a file', async ({ client }) => {
  const file = await File.create({
    file: 'fixture.png',
    name: 'image.png',
    type: 'image',
    subtype: 'png'
  })

  const response = await client
    .get(`/file/${file.id}`)
    .send()
    .end()

  response.assertStatus(200)
})
