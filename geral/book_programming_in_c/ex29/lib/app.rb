#!/usr/bin/env ruby

# frozen_string_literal: true

(1..10).each { |n| puts format("%<n>2i\t%<square>6.2f", n: n, square: n**2) }
