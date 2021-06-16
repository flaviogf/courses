regex1 = /^[0-9]/

regex2 = Regexp.new("^[0-9]")

regex3 = %r{^[0-9]}

puts "1 teste" =~ regex1

puts "1 teste" =~ regex2

puts "1 teste" =~ regex3

puts "outro teste" !~ regex1

puts "outro teste" !~ regex2

puts "outro teste" !~ regex3

puts "1 teste" !~ regex1

puts "1 teste" !~ regex2

puts "1 teste" !~ regex3
