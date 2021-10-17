#!/usr/bin/env ruby

# frozen_string_literal: true

def division_by_zero_error
  puts 'Division by zero is not allowed'
  exit!(-1)
end

print 'Type in two numbers to divide them: '
x, y = gets.chomp.to_s.split(' ').collect(&:to_f)

division_by_zero_error if y.zero?

result = x / y

puts format('%<x>.3f / %<y>.3f = %<result>.3f', x: x, y: y, result: result)
