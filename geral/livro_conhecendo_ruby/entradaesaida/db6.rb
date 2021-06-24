# frozen_string_literal: true

require 'active_record'

ActiveRecord::Base.establish_connection adapter: 'sqlite3', database: 'students.sqlite3'

class Student < ActiveRecord::Base
end

Student.find_each do |student|
  puts "id: #{student.id} name: #{student.name}"
end
