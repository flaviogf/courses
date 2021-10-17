#!/usr/bin/env ruby

# frozen_string_literal: true

module Helper
  def divisible?(number)
    (to_f % number.to_f).zero?
  end
end

class Object
  include Helper
end

print 'Type in two numbers to discover if the first one is divisible for the seconde one: '
x, y = gets.chomp.to_s.split(' ')

answer = x.divisible?(y) ? 'It is divisible!' : 'It is not divisible!'

puts answer
