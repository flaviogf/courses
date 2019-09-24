from collections import Counter


with open('text_1.txt') as file:
    text_1 = file.read()

with open('text_2.txt') as file:
    text_2 = file.read()

def text_analize(text):
    frequency = Counter([i for i in text])

    for key, value in frequency.most_common(10):
        print(key, '=>', value)


print("*" * 100)
text_analize(text_1)
print("*" * 100)
text_analize(text_2)
