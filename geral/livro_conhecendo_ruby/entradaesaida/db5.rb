# frozen_string_literal: true

require 'sequel'

DB = Sequel.sqlite database: 'students.sqlite3'

ds = DB[:students].filter id: :$i

ps = ds.prepare :select, :select_by_id

1.upto(4) do |id|
  print "searching for id #{id} ... "
  row = ps.call(i: id)
  puts row.first[:name]
end
