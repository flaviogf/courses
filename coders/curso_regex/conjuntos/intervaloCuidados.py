import re

texto = 'ABC [abc] a-c'

print(re.findall(r'[a-z]', texto, re.IGNORECASE))
print(re.findall(r'a-c', texto))
print(re.findall(r'[A-z]', texto))
print(re.findall(r'[Z-a]', texto))
# print(re.findall(r'[a-Z]', texto)) erro de sintaxe
