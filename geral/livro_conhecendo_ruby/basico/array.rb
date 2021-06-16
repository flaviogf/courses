array = [1, 2, 3, 4, 5]

puts array

array = %w(um dois tres quatro)

puts array

array = %i(um dois tres quatro)

puts array

array = Array.new(5)

puts array

array = Array.new(5, "oi")

puts array

array = Array.new(5) { "oi" }

puts array

a = %w(john paul george ringo)

puts a[0..1]

puts a[1..2]

puts a[1..3]

puts a[-1]

puts a.last

puts a.take(2)

array = [0, [1, [2, 3]]]

puts array[1][1][0]

puts array.dig(1, 1, 0)
