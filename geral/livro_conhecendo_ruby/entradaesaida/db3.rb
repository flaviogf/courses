# frozen_string_literal: true

require 'sequel'

DB = Sequel.sqlite database: 'students.sqlite3'

students = DB[:students]

name = 'Temporary'

students.insert name: name

students.where(name: name).delete
