# frozen_string_literal: true

require 'net/http'

uri = URI('http://eustaquiorangel.com')

response = Net::HTTP.get(uri)

p response
