#!/usr/bin/env ruby

# frozen_string_literal: true

print 'Enter you number to be tested: '
number_to_test = gets.chomp.to_i

if number_to_test.even?
  puts 'The number is even.'
else
  puts 'The number is odd.' end
