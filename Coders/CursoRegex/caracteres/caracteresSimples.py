import re

texto = '1,2,3,4,5,6,a.b c!d?e'

print(re.search(r',', texto).group(0))
print(re.findall(r',', texto))
print(re.search(r'A', texto))
print(re.search(r'A', texto, re.IGNORECASE).group(0))
print(re.search(r'a.b c!d?', texto).group(0))
