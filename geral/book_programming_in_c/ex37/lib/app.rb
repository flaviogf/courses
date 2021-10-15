#!/usr/bin/env ruby

# frozen_string_literal: true

def sign(number)
  return -1 if number.negative?
  return 0 if number.zero?
  1
end

print 'Please type in a number: '
number = gets.chomp.to_i
puts "Sign = #{sign(number)}"
