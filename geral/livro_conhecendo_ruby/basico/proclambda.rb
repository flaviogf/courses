vezes3 = Proc.new { |valor| valor * 3 }

puts vezes3.call 3

puts vezes3.call 4

puts vezes3.call 5

vezes5 = lambda { |valor| valor * 5 }

puts vezes5.call 5

puts vezes5.call 6

puts vezes5[8]

puts vezes5.(5)

(1..5).map &vezes5
