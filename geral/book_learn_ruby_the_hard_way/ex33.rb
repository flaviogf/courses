# frozen_string_literal: true

i = 0
numbers = []

while i < 6
  puts "At the top is #{i}"
  numbers.push(i)
  i += 1
  puts "Numbers now: #{numbers.inspect}"
  puts "At the bottom i is #{i}"
end

puts 'The numbers: '

numbers.each { |num| puts num }

puts 'The numbers: (again)'

numbers.each do |num|
  puts num
end
