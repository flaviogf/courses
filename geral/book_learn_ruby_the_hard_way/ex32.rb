# frozen_string_literal: true

the_count = [1, 2, 3, 4, 5]

fruits = ['apple', 'oranges', 'pears', 'apricots']

change = [1, 'pennies', 2, 'dimes', 3, 'quarters']

for number in the_count
  puts "This is count #{number}"
end

fruits.each do |fruit|
  puts "A fruit of type: #{fruit}"
end

change.each { |i| puts "I got #{i}" }

elements = []

(0..5).each do |i|
  elements.push(i)
end

elements.each { |i| puts "Element was: #{i}" }
