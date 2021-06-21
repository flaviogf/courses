# frozen_string_literal: true

require 'socket'

server = UDPSocket.new
porta = 1234
server.bind 'localhost', porta
puts "Servidor conectado na porta #{porta}, aguardando"

loop do
  msg, sender = server.recvfrom 256
  host = sender[3]
  puts "Host #{host} enviou um pacote UDP: #{msg}"
  break unless msg.chomp != 'kill'
end

server.close
