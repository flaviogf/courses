curl -XGET 'localhost:9200/news_headlines/_search' -H 'Content-Type: application/json' -d '{
  "aggs": {
    "by_category": {
      "terms": { "field": "category", "size": 100 }
    }
  }
}'
