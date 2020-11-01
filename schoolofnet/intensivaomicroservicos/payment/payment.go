package main

import (
	"encoding/json"
	"time"

	"github.com/flaviogf/payment/queue"
)

func main() {
	in := make(chan []byte)

	channel, _ := queue.Connect()

	queue.Consuming("order_queue", in, channel)

	for message := range in {
		var order Order

		json.Unmarshal(message, &order)

		order.Status = "Aprovado"

		notifyPayment(order)
	}
}

func notifyPayment(order Order) {
	bytes, _ := json.Marshal(order)

	channel, _ := queue.Connect()

	queue.Notify("payment_ex", bytes, channel)
}

type Order struct {
	UUID      string    `json:"uuid"`
	Name      string    `json:"name"`
	Email     string    `json:"email"`
	Phone     string    `json:"phone"`
	ProductID string    `json:"product_id"`
	Status    string    `json:"status"`
	CreatedAt time.Time `json:"created_at,string"`
}
