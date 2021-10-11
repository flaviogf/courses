#!/usr/bin/env ruby

# frozen_string_literal: true

def factorial(number)
  return number if number.zero? || number == 1

  number * factorial(number - 1)
end

pp factorial(5)
