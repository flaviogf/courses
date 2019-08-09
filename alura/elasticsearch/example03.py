import json

from requests import post


response = post('http://localhost:9200/customer/_doc/1?pretty', json={'name': 'John Doe'})


print(response.json())
