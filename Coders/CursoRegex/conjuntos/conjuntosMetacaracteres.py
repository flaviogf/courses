import re

texto = '$*-+?.'

print(re.findall(r'[-$*+?.]', texto))
print(re.findall(r'[$-?]', texto))
print(re.findall(r'[$*\-+?.]', texto))
print(re.findall(r'[$*\-+?.].', texto))
