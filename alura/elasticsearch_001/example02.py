from requests import get

response = get('http://localhost:9200/_cat/indices?v')

print(response.text)
