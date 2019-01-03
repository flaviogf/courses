import re

texto = '1,2,3,4,5,6,a.b c?d!e[f'

print(re.findall(r'\w', texto))
print(re.findall(r'\W', texto))
print(re.findall(r'\d', texto))
print(re.findall(r'\D', texto))
print(re.findall(r'\s', texto))
print(re.findall(r'\S', texto))
