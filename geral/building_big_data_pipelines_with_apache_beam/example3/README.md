```sh
export KAFKA_SERVER=localhost:9092
export KAFKA_TOPIC=first_topic

kafka-topics --bootstrap-server $KAFKA_SERVER --create --topic $KAFKA_TOPIC

kafka-console-consumer --bootstrap-server $KAFKA_SERVER --topic $KAFKA_TOPIC

echo "First Message!" | kafka-console-producer --bootstrap-server $KAFKA_SERVER --topic $KAFKA_TOPIC
```
