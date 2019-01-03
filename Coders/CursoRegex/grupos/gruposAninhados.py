import re

texto = 'supermercado hipermercado minimercado mercado'

for item in re.finditer(r'(super|hiper|mini)?mercado', texto):
    print(item.group())

for item in re.finditer(r'((su|hi)per|mini)?mercado', texto):
    print(item.group())
