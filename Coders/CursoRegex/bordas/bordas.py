import re

texto = 'Testando o funcinamento\n das bordas'

print(re.findall(r'^t', texto, re.IGNORECASE | re.DOTALL))
print(re.findall(r's$', texto, re.IGNORECASE | re.DOTALL))
print(re.findall(r'^t.*s$', texto, re.IGNORECASE | re.DOTALL))
