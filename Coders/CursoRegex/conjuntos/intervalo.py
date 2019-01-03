import re

texto = '1,2,3,4,5,6,a.b c!d?e[f'

print(re.findall(r'[1-3]', texto))
print(re.findall(r'[b-e]', texto))
print(re.findall(r'[A-Z1-3]', texto, re.IGNORECASE))
