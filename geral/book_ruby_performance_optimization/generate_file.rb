# frozen_string_literal: true

GC.disable

before = `ps -o rss= -p #{Process.pid}`.to_i / 1024

content = "x\n" * 1024 * 1024 * 13

after = `ps -o rss= -p #{Process.pid}`.to_i / 1024
usage = after - before

puts "usage: #{usage} MB"

File.open('output.txt', mode: 'w') { |f| f.write(content) }
