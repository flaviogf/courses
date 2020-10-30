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

func Consuming(in chan []byte, channel *amqp.Channel) error {
	queue, err := channel.QueueDeclare("checkout_queue", true, false, false, false, nil)

	if err != nil {
		return err
	}

	messages, err := channel.Consume(queue.Name, "checkout", true, false, false, false, nil)

	if err != nil {
		return err
	}

	go func() {
		for message := range messages {
			in <- message.Body
		}
	}()

	return nil
}
