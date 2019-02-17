import re

texto = 'a   b'

print(re.search(r'a\s{3}b', texto).group(0))
print(re.search(r'a\s+b', texto).group(0))
