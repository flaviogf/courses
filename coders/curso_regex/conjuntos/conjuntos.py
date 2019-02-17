import re

texto = '1,2,3,4,5,6,a.b c!d?e[f'
texto2 = 'Jão não vai passear de moto'

print(re.findall(r'[0246]', texto))
print(re.findall(r'n[aã]o', texto2))
