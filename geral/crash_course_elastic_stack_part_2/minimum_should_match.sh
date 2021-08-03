curl -XGET 'localhost:9200/news_headlines/_search' -H 'Content-Type: application/json' -d '{
  "query": {
    "match": {
      "headline": {
        "query": "Khloe Kardashian Kendall Jenner",
        "minimum_should_match": 3
      }
    }
  }
}'
