#!/usr/bin/env ruby

# frozen_string_literal: true

puts 'Enter your number:'
number = Integer(gets.chomp)

loop do
  right_digit = number % 10
  print right_digit
  number /= 10
  break if number.zero?
end

puts
