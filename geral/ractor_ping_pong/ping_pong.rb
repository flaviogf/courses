# frozen_string_literal: true

server = Ractor.new do
  puts 'server starting...'
  Ractor.yield(:ping)
  res = Ractor.receive
  puts "server received: #{res}"
end

client = Ractor.new(server) do |srv|
  puts 'client starting...'
  res = srv.take
  puts "client received: #{res}"
  srv.send(:pong)
end

[client, server].each(&:take)
