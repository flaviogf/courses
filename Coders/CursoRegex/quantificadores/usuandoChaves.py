import re

texto = 'O João recebeu 120 milhões apostando 6 9 21 23 45 46'

print(re.findall(r'\d{1,2}', texto))
print(re.findall(r'\d{2}', texto))
print(re.findall(r'[0-9]{1,}', texto))

print(re.findall(r'\w{7}', texto))
print(re.findall(r'[\wõ]{7}', texto))
print(re.findall(r'\w{7,}', texto))
