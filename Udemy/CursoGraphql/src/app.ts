require('dotenv').config()

import * as express from 'express'

import * as graphqlHTTTP from 'express-graphql'

import schema from './graphql/schema'

const app = express()

app.use('/graphql', graphqlHTTTP({
  graphiql: true,
  schema
}))

app.listen(process.env.PORTA, () => {
  console.log(`[API - ${process.env.NOME_API}] - [PORTA - ${process.env.PORTA}]`)
})
