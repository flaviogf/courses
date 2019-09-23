from collections import defaultdict

sentence = 'What would you like to have?'

words = sentence.split(' ')

print(words)

dictionary = defaultdict(int)

for word in words:
    dictionary[word] += 1

print(dictionary)
