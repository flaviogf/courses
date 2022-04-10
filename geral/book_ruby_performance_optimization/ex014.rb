require_relative 'wrapper'
require 'csv'

measure do
  CSV.open('output.txt') do |csv|
    while (_ = csv.readline)
    end
  end
end
