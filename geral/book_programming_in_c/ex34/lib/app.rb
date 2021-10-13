#!/usr/bin/env ruby

# frozen_string_literal: true

print 'How many grades will you be entering? '
number_of_grades = gets.chomp.to_i

grade_total, failure_count = (0...number_of_grades).each_with_object([0, 0]) do |n, memo|
  print format('Enter grade #%<n>i: ', n: n)
  grade = gets.chomp.to_i
  memo[0] += grade
  memo[1] += 1 if grade < 65
end

average = grade_total.to_f / number_of_grades

puts format("\nGrade average = %<average>.2f", average: average)
puts format('Number of failures = %<failure_count>i', failure_count: failure_count)
