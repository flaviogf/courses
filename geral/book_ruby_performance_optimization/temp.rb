GC.disable

memory_before = `ps -o rss= -p #{Process.pid}`.to_i / 1024

Array.new(1) { 'x' * 1024 * 1024 }

memory_after = `ps -o rss= -p #{Process.pid}`.to_i / 1024

puts "#{memory_after - memory_before} MB"
