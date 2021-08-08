# frozen_string_literal: true

filename = ARGV.first

puts "We're going to erase #{filename}"
puts "If you don't want that, hit CTRL-C."
puts 'If you do want that, hit RETURN.'

$stdin.gets

puts 'Opening the file...'
target = open(filename, 'w')

puts 'Truncating the file. Goodbye!'
target.truncate(0)

puts "Now I'm going to ask you for three lines."

lines = (1..3).collect do |i|
  print "line #{i}: "
  $stdin.gets.chomp
end

puts "I'm going to write these to the file."

lines.each do |line|
  target.write("#{line}\n")
end

puts 'And finally, we close it'

target.close
