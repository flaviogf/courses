import re

texto = 'lista de arquivos mp3: jazz.mp3,rock.mp3,podcast.mp3,blues.mp3'

print(re.findall(r'\.mp3', texto))
print(re.findall(r'\w+\.mp3', texto))
