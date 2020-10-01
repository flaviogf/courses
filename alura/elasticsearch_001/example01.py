from requests import put, delete

response = delete('http://localhost:9200/customer')

print(response.json())

response = put('http://localhost:9200/customer?pretty')

print(response.json())
