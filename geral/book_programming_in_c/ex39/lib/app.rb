#!/usr/bin/env ruby

# frozen_string_literal: true

puts 'Type in your expression'
expression = gets.chomp.to_s
begin
  puts format('%<result>.2f', result: eval(expression))
rescue StandardError
  puts 'Oops, this is not a valid expression'
end
