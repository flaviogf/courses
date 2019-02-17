import re

texto = '<b>Descricao</b><h1>Descricao</h1>'

for item in re.finditer(r'<(\w+)>.*</\1>', texto):
    print(item.group())
