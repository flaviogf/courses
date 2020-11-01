package main

import (
	"context"
	"encoding/json"
	"flag"
	"io/ioutil"
	"net/http"
	"os"
	"time"

	uuid "github.com/satori/go.uuid"

	"github.com/flaviogf/order/db"
	"github.com/flaviogf/order/queue"
)

var ctx = context.Background()

func main() {
	var option string

	flag.StringVar(&option, "o", "", "Usage")

	flag.Parse()

	in := make(chan []byte)

	connection, _ := queue.Connect()

	switch option {
	case "checkout":
		queue.Consuming("checkout_queue", in, connection)

		for message := range in {
			var order Order

			json.Unmarshal(message, &order)

			order.UUID = uuid.NewV4().String()
			order.Status = "Pendente"
			order.CreatedAt = time.Now()

			saveOrder(order)

			notifyOrder(order)
		}
	case "payment":
		queue.Consuming("payment_queue", in, connection)

		for message := range in {
			var order Order

			json.Unmarshal(message, &order)

			saveOrder(order)
		}
	}

}

func getProductById(id string) (Product, error) {
	url := os.Getenv("PRODUCT_URL")

	resp, _ := http.Get(url + "/products/" + id)

	item, _ := ioutil.ReadAll(resp.Body)

	var product Product

	json.Unmarshal(item, &product)

	return product, nil
}

func saveOrder(order Order) {
	bytes, _ := json.Marshal(order)

	client := db.Connect()

	client.Set(ctx, order.UUID, string(bytes), 0)
}

func notifyOrder(order Order) {
	bytes, _ := json.Marshal(order)

	channel, _ := queue.Connect()

	queue.Notify("order_ex", bytes, channel)
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
