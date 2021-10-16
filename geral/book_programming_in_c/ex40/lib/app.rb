#!/usr/bin/env ruby

# frozen_string_literal: true

puts 'Type in your expression.'
x, operator, y = gets.chomp.split(' ')

case operator
when '+' then puts format('%<result>.2f', result: Float(x) + Float(y))
when '-' then puts format('%<result>.2f', result: Float(x) - Float(y))
when '*' then puts format('%<result>.2f', result: Float(x) * Float(y))
when '/' then puts format('%<result>.2f', result: Float(x) / Float(y))
else puts 'Oops, this is not a valid expression'
end
