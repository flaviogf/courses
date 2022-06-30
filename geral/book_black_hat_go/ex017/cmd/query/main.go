package main

import (
	"context"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

const uri = "mongodb://root:example@localhost:27017"

func main() {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	client, err := mongo.Connect(ctx, options.Client().ApplyURI(uri))

	if err != nil {
		log.Fatalln(err)
	}

	defer func(ctx context.Context) {
		if err := client.Disconnect(ctx); err != nil {
			log.Fatalln(err)
		}
	}(ctx)

	collection := client.Database("store").Collection("transactions")

	cursor, err := collection.Find(ctx, bson.D{{}}, options.Find())

	if err != nil {
		log.Fatalln(err)
	}

	var results []bson.D

	if err = cursor.All(ctx, &results); err != nil {
		log.Fatalln(err)
	}

	for _, result := range results {
		log.Println(result)
	}
}
