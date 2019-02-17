import re

texto = '''
c	a r
r o
'''

print(re.search(r'c\ta\sr\nr\so', texto).group(0))
