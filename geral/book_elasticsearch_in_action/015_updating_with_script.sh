curl -XPUT 'localhost:9200/online-shop/_doc/2' -H 'Content-Type: application/json' -d '{
  "caption": "Learning Elasticsearch",
  "price": 15
}'

curl -XPOST 'localhost:9200/online-shop/_doc/2/_update' -H 'Content-Type: application/json' -d '{
  "script": {
    "source": "ctx._source.price += params.price_diff",
    "params": {
      "price_diff": 10
    }
  }
}'
