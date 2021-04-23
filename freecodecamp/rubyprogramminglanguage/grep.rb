#!/usr/local/bin/ruby

search_query = ARGV[0]

STDIN.select { |line| line.upcase.include? search_query.upcase }.each { |line| puts line }

