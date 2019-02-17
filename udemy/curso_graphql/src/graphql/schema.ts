import { makeExecutableSchema } from 'graphql-tools'

const usuarios = [
  {
    id: 1,
    nome: 'flavio',
    email: 'flavio@email.com'
  },
  {
    id: 2,
    nome: 'fernando',
    email: 'fernando@email.com'
  }
]

const typeDefs = `
  type Usuario {
    id: Int!,
    nome: String!
    email: String!
  }

  type Query {
    listaUsuarios: [Usuario!]!
  }

  type Mutation {
    insereUsuario(nome: String!, email: String!): Usuario!
  }
`

const resolvers = {
  Usuario: {
    id: (parent) => {
      console.log('resolver - usuario.id chamado')
      return parent.id
    }
  },
  Query: {
    listaUsuarios: () => {
      return usuarios
    }
  },
  Mutation: {
    insereUsuario(parent, args, context, info) {
      const usuario = { ...args, id: usuarios.length + 1 }
      usuarios.push(usuario)
      return usuario
    }
  }
}

export default makeExecutableSchema({ typeDefs, resolvers })
