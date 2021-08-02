curl -XGET 'localhost:9200/news_headlines/_search' -H 'Content-Type: application/json' -d '{
  "track_total_hits": true
}'
