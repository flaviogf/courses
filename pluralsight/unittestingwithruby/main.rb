require_relative 'lib/factorial.rb'
require_relative 'lib/sort.rb'

puts Factorial.recursive(7)

puts Factorial.iterative(7)

numbers = [10, 5, 25, 15, 35, 30]

Sort.quicksort(numbers, 0, 5)

puts numbers
