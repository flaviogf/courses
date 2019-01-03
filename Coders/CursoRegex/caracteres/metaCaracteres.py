import re

texto = '1,2,3,4,5,6,a.b c!d?e'

print(re.split(r',|\.| |!|\?', texto))
