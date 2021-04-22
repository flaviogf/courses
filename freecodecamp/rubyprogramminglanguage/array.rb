favorite_characters = ["Frank", "Peter", "Bruce", "Barry"]

puts favorite_characters

puts ("First: " + favorite_characters[0])

puts ("Last: " + favorite_characters[-1])

print "From 1 to 3 (inclusive): "
print favorite_characters[1..3]
print "\n"

print "From 1 to 3 (exclusive): "
print favorite_characters[1...3]
print "\n"

puts ("Does it include \"Frank\"? " + favorite_characters.include?("Frank").to_s)

puts ("Does it include \"Clark\"? " + favorite_characters.include?("Clark").to_s)
