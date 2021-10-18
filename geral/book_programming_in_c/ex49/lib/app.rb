#!/usr/bin/env ruby

# frozen_string_literal: true

fibonnaci = [0, 1]

(2...15).each { |i| fibonnaci[i] = fibonnaci[i - 2] + fibonnaci[i - 1] }

fibonnaci.each { |i| puts i }
