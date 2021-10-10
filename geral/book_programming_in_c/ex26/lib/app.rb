#!/usr/bin/env ruby

# frozen_string_literal: true

puts 'Enter your number:'

number = Integer(gets.chomp)

while number != 0
  right_digit = number % 10
  print right_digit
  number /= 10
end

puts
