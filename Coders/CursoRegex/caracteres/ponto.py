import re

texto = '1,2,3,4,5,6,7,8,9,0'

print(re.search(r'1.2', texto).group())
print(re.search(r'1..', texto).group())
print(re.search(r'1..2', texto))
print(re.search(r'1..,', texto).group())

notas = '8.3,9.0,8.0,10.0'
print(re.findall(r'8..', notas))
print(re.findall(r'.\..', notas))
