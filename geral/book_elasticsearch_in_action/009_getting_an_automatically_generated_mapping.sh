curl -XPUT 'localhost:9200/get-together/new-events/1' -H 'Content-Type: application/json' -d '{
  "name": "Late Night with Elasticsearch",
  "date": "2013-10-25T19:00"
}'

curl 'localhost:9200/get-together/_mapping'
