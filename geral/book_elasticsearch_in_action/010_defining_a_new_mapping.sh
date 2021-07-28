curl -XPUT 'localhost:9200/get-together/_mapping' -H 'Content-Type: application/json' -d '{
  "properties": {
    "host": {
      "type": "text"
    }
  }
}'
