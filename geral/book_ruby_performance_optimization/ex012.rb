require_relative 'wrapper'
require 'csv'

measure do
  CSV.read('output.txt')
end
