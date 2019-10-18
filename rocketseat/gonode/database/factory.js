'use strict'

/*
|--------------------------------------------------------------------------
| Factory
|--------------------------------------------------------------------------
|
| Factories are used to define blueprints for database tables or Lucid
| models. Later you can use these blueprints to seed your database
| with dummy data.
|
*/

/** @type {import('@adonisjs/lucid/src/Factory')} */
const Factory = use('Factory')
const Hash = use('Hash')

Factory.blueprint('App/Models/User', async (faker) => {
  return {
    email: faker.email(),
    password: await Hash.make(faker.password())
  }
})

Factory.blueprint('App/Models/File', (faker) => {
  return {
    file: faker.word(),
    name: faker.word(),
    type: faker.word(),
    subtype: faker.word()
  }
})

Factory.blueprint('App/Models/Project', async (faker, _, data) => {
  return {
    title: faker.word(),
    description: faker.word(),
    ...data
  }
})
