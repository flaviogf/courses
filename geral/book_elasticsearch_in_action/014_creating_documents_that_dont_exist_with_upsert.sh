curl -XPOST 'localhost:9200/get-together/_doc/2/_update' -H 'Content-Type: application/json' -d '{
  "doc": {
    "organizer": "Roy"
  },
  "upsert": {
    "name": "Elasticsearch Denver",
    "organizer": "Roy"
  }
}'
