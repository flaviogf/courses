#!/usr/bin/env ruby

# frozen_string_literal: true

puts 'Enter a single character:'
char = gets.chomp.to_s

case char
when ->(it) { ('a'..'z').include?(it) || ('A'..'Z').include?(it) }
  puts "It's an alphabetic character."
when ->(it) { ('0'..'9').include?(it) }
  puts "It's a digit."
else
  puts "It's a special character."
end
