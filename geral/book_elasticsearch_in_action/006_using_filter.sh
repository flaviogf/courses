curl 'localhost:9200/get-together/group/_search' -H 'Content-Type: application/json' -d '{
  "query": {
    "term": {
      "name": "elasticsearch"
    }
  }
}'
