from requests import get


response = get('http://localhost:9200/customer/_doc/1?pretty')

print(response.json())
