# frozen_string_literal: true

require 'sequel'

DB = Sequel.sqlite database: 'students.sqlite3'

DB.drop_table? :students

DB.create_table :students do
  primary_key :id
  String :name
end

students = DB[:students]

10.times do |i|
  students.insert name: "Student #{i}"
end
