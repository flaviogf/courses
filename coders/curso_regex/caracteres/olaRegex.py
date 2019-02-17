from re import findall, IGNORECASE, search
from os import listdir

texto = 'Casa bonita é a casa amarela da esquina da Rua ACASALAR'

print(findall(r'casa', texto, IGNORECASE))
print(search(r'a b', texto, IGNORECASE).group(0))
