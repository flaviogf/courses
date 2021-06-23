# frozen_string_literal: true

require 'xmlrpc/server'

server = XMLRPC::Server.new 8081

server.add_handler 'sum' do |x, y|
  { 'result' => x + y }
end

server.serve
