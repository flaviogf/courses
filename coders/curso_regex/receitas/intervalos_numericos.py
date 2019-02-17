import re

texto = '12 98 100 256 8 255 300 249 257'

print(re.findall(r'\b(\d{1,2}|1\d{2}|2[0-4]\d|25[0-5])\b', texto))
