curl -XGET 'localhost:9200/news_headlines/_search' -H 'Content-Type: application/json' -d '{
  "query": {
    "match": {
      "headline": "Khloe Kardashian Kendall Jenner"
    }
  }
}'
