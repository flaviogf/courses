# frozen_string_literal: true

thread = Thread.new do
  puts "Thread #{object_id} started"
  5.times do |i|
    puts i
    sleep 1
  end
end

puts 'thread already started'

thread.join 3
