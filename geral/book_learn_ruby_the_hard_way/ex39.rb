# frozen_string_literal: true

things = %w[a b c d]

puts things[1]

things[1] = 'z'

puts things[1]

stuff = { 'name' => 'Zed', 'age' => 39, 'height' => 6 * 12 + 2 }

puts stuff['name']
puts stuff['age']
puts stuff['height']

stuff['city'] = 'San Francisco'
puts stuff['city']

stuff[1] = 'Wow'
stuff[2] = 'Neato'
puts stuff[1]
puts stuff[2]

pp stuff

stuff.delete('city')

pp stuff
