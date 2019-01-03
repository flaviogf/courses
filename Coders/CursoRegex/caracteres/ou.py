import re

texto = 'Diga sim não ou, não sei'

print(re.findall(r'sim|não|sei', texto))
print(re.findall(r'sim|não sei|não', texto))
print(re.findall(r'sim|n.o|sei', texto))
