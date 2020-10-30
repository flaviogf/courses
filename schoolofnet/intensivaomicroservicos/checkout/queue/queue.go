package queue

import (
	"os"

	"github.com/streadway/amqp"
)

func Connect() (*amqp.Channel, error) {
	connection, err := amqp.Dial(os.Getenv("AMQP_URL"))

	if err != nil {
		return nil, err
	}

	channel, err := connection.Channel()

	if err != nil {
		return nil, err
	}

	return channel, nil
}

func Notify(exchange string, body []byte, channel *amqp.Channel) error {
	message := amqp.Publishing{
		ContentType: "application/json",
		Body:        body,
	}

	err := channel.Publish(exchange, "", false, false, message)

	return err
}
