package queue

import (
	"fmt"
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

	return channel, err
}

func Consuming(name string, in chan []byte, channel *amqp.Channel) error {
	queue, err := channel.QueueDeclare(name, true, false, false, false, nil)

	if err != nil {
		fmt.Println(err)
		return err
	}

	messages, err := channel.Consume(queue.Name, "payment", true, false, false, false, nil)

	if err != nil {
		fmt.Println(err)
		return err
	}

	go func() {
		for message := range messages {
			in <- message.Body
		}
	}()

	return nil
}

func Notify(exchange string, body []byte, channel *amqp.Channel) error {
	err := channel.Publish(exchange, "", false, false, amqp.Publishing{
		ContentType: "application/json",
		Body:        body,
	})

	return err
}
