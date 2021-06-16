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

puts regex1.match? "1 teste"

puts "o rato roeu a roupa do rei de Roma".scan(/r[a-z]+/i)

"Frank Castle" =~ /(\w+)( )(\w+)/

puts $1 + $2 + $3

puts "Frank Castle".sub(/(\w+)( )(\w+)/i, '\3 \1')

matcher = /(?<objeto>\w{5})(.*)(?<cidade>\w{4})$/.match("o rato roeu a roupa do rei de Roma")

puts matcher[:objeto]

puts matcher[:cidade]

puts matcher.named_captures
