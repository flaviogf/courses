require 'benchmark'

number_of_rows = 5999
number_of_columns = 100

GC.disable

data = Array.new(number_of_rows) { Array.new(number_of_columns) { 'x' * 1000 } }

time = Benchmark.realtime do
  _ = data.collect { |row| row.join(',') }.join('\n')
end

puts time.round(2)
