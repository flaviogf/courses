import re

texto1 = 'De longe eu avistei o fogo e uma pessoa gritando: FOGOOOOOO'
texto2 = 'There is a big fog in NYC'

regex1 = r'fogo+'

print(re.findall(regex1, texto1, re.IGNORECASE))
print(re.findall(regex1, texto2, re.IGNORECASE))

texto3 = 'Os numeros 0123456789.'

regex2 = r'\d'
print(re.findall(regex2, texto3))

regex3 = r'\d+'
print(re.findall(regex3, texto3))

regex4 = r'\d+?'
print(re.findall(regex4, texto3))
