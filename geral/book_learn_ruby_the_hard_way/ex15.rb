# frozen_string_literal: true

filename = ARGV.first

text = open(filename)

puts "Here's your file #{filename}"

print text.read

text.close

print 'Type the filename again: '
file_again = $stdin.gets.chomp

txt_again = open(file_again)
print txt_again.read

txt_again.close
