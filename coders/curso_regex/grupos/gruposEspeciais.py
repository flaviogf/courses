import re

texto = 'Testando, grupos especias!'

texto2 = 'supermercado superacao hiperMERCADO'

# lookahead
print(re.findall(r'\w+(?=,|!)', texto))

# lookbehind
# positive
print(re.findall(r'(?<=super)\w+', texto2))
# negative
print(re.findall(r'(?<!super)mercado', texto2, re.IGNORECASE))
