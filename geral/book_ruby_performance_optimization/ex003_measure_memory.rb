require 'benchmark'

num_rows = 100_000
num_cols = 10

data = Array.new(num_rows) { Array.new(num_cols) { 'x' * 1000 } }

puts "#{`ps -o rss= -p #{Process.pid}`.to_i / 1024} MB"

GC.disable

time = Benchmark.realtime do
  _ = data.map { |row| row.join(',') }.join('\n')
end

puts "#{`ps -o rss= -p #{Process.pid}`.to_i / 1024} MB"

puts time.round(2)
