# frozen_string_literal: true

require 'xmlrpc/client'

client = XMLRPC::Client.new 'localhost', '/RPC2', 8081

resp = client.call 'sum', 5, 3

puts "The result of the sum is #{resp['result']}"
