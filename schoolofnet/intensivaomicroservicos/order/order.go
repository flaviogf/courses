package main

import (
	"fmt"
	"time"

	"github.com/flaviogf/order/queue"
)

func main() {
	in := make(chan []byte)

	connection, _ := queue.Connect()

	queue.Consuming(in, connection)

	for message := range in {
		fmt.Println(string(message))
	}
}

type Product struct {
	UUID    string  `json:"uuid"`
	Product string  `json:"product"`
	Price   float64 `json:"price,string"`
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
