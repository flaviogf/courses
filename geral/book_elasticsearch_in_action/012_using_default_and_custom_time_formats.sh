curl -XPUT 'localhost:9200/weekly-events' -H 'Content-Type: application/json' -d '{
  "mappings": {
    "properties": {
      "next_event": {
        "type": "date",
        "format": "MMM DD YYYY"
      }
    }
  }
}'

curl -XPUT 'localhost:9200/weekly-events/_doc/1' -H 'Content-Type: application/json' -d '{
  "name": "Elasticsearch News",
  "first_ocurrence": "2011-04-03",
  "next_event": "Oct 25 2013"
}'
