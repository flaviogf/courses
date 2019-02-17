import re

texto = 'dia diafragma media'

print(re.findall(r'\bdia', texto)) # dia diafragma
print(re.findall(r'dia\b', texto)) # dia media
print(re.findall(r'\bdia\b', texto)) # dia
