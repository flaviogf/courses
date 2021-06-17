puts 'Digite um número'

i = gets.chomp.to_i

case i
when 0..5
  puts 'Entre 0 e 5'
when 6..10
  puts 'Entre 6 e 10'
else
  puts 'hein?'
end
