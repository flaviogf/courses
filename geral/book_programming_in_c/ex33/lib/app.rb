#!/usr/bin/env ruby

# frozen_string_literal: true

print 'Type in your number: '
number = gets.chomp.to_i
number = -number if number.negative?
puts format('The absolute value is %<number>i', number: number)
