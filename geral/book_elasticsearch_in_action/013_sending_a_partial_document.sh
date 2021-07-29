curl -XPUT 'localhost:9200/get-together/_doc/1' -H 'Content-Type: application/json' -d '{
  "name": "Elasticsearch Denver",
  "organizer": "Lee"
}'

curl -XPOST 'localhost:9200/get-together/_doc/1/_update' -H 'Content-Type: application/json' -d '{
  "doc": {
    "organizer": "Roy"
  }
}'
