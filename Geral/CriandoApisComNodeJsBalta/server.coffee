debug = require 'debug'
http = require 'http'
dotenv = require 'dotenv'

dotenv.config()

app = require './src/app'

server = http.createServer app

server.listen process.env.PORT, () ->
  console.log "API rodando na porta: #{process.env.PORT}"

server.on 'error', (error) ->
  console.error  error
  process.exit -1

server.on 'listening', () ->
  debug('nodestr:server')('Node Store Api', server.address)
