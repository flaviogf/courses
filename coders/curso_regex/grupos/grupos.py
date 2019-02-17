import re

texto = 'http://www.site.info www.escolaninja.com.br google.com.br'

for item in re.finditer(r'(http://)?(\w{3}\.)?\w+\.\w+(\.\w{2})?', texto):
    print(item.group())
