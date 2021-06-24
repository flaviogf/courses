# frozen_string_literal: true

require 'sequel'

DB = Sequel.sqlite database: 'students.sqlite3'

DB[:students].each do |row|
  puts "id: #{row[:id]} name: #{row[:name]}"
end
