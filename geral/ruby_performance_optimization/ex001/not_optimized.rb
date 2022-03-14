require 'benchmark'

number_of_rows = 5999
number_of_columns = 100

data = Array.new(number_of_rows) { Array.new(number_of_columns) { 'x' * 1_000 } }

time = Benchmark.realtime do
  _ = data.map { |row| row.join(',') }.join('\n')
end

puts time.round(2)
