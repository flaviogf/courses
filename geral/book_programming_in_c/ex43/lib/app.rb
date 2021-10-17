#!/usr/bin/env ruby

# frozen_string_literal: true

module Helper
  def prime?
    (2...self).none? { |n| (self % n).zero? }
  end
end

class Integer
  include Helper
end

(2...50).select(&:prime?).each { |n| print "#{n} " }

puts
