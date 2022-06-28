package main

import (
	"context"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

func main() {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	client, err := mongo.Connect(ctx, options.Client().ApplyURI("mongodb://root:example@localhost:27017"))

	if err != nil {
		log.Fatalln(err)
	}

	defer func(ctx context.Context) {
		err := client.Disconnect(ctx)

		if err != nil {
			log.Fatalln(err)
		}
	}(ctx)

	collection := client.Database("store").Collection("transcations")

	docs := []interface{}{
		bson.D{
			{"ccnum", "4444333322221111"},
			{"date", "2019-01-05"},
			{"amount", 100.12},
			{"cvv", "1234"},
			{"exp", "09/2020"},
		},
		bson.D{
			{"ccnum", "4444123456789012"},
			{"date", "2019-01-07"},
			{"amount", 2400.18},
			{"cvv", "5544"},
			{"exp", "02/2021"},
		},
		bson.D{
			{"ccnum", "4465122334455667"},
			{"date", "2019-01-29"},
			{"amount", 1450.87},
			{"cvv", "9876"},
			{"exp", "06/2020"},
		},
	}

	_, err = collection.InsertMany(ctx, docs)

	if err != nil {
		log.Fatalln(err)
	}

	log.Println("Database seeded")
}
