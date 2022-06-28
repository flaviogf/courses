package main

import (
	"context"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"go.mongodb.org/mongo-driver/mongo/readpref"
)

func main() {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	client, err := mongo.Connect(ctx, options.Client().ApplyURI("mongodb://localhost:27017"))

	if err != nil {
		log.Fatalln(err)
	}

	defer func(ctx context.Context) {
		err := client.Disconnect(ctx)

		if err != nil {
			log.Fatalln(err)
		}
	}(ctx)

	err = client.Ping(ctx, readpref.Primary())

	if err != nil {
		log.Fatalln(err)
	}

	log.Println("It works")
}
