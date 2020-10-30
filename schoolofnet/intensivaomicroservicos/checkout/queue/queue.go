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
