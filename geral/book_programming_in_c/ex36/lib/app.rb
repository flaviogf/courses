#!/usr/bin/env ruby

# frozen_string_literal: true

def leap?(year)
  ((year % 4).zero? && (year % 100).zero?) || (year % 400).zero?
end

print 'Enter the year to be tested: '

year = gets.chomp.to_i

if leap?(year)
  puts "It's a leap year."
else
  puts "Nope, it's not a leap year."
end
