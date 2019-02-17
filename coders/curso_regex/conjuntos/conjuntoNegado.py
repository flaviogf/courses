import re

texto = '1,2,3,4,5,6,a.b c?d[ef!'

print(re.findall(r'[^.?\[,\s!3-5]', texto))
