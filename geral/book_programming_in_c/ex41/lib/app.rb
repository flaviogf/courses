#!/usr/bin/env ruby

# frozen_string_literal: true

class Integer
  def prime?
    (2...self).none? { |n| (self % n).zero? }
  end
end

(2..50).select(&:prime?).each { |n| print "#{n} " }

puts
