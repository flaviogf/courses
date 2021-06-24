# frozen_string_literal: true

require 'sequel'

DB = Sequel.sqlite database: 'students.sqlite3'

students = DB[:students]

1.upto(10) do |i|
  students.where(id: i).update name: "Student #{i} updated"
end
