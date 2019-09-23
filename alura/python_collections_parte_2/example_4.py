from collections import Counter

sentence =  'I did end Gears of War in last weekend. And now I will start to play God of War.'

words = sentence.split(' ')

counter = Counter(words)

print(counter)
