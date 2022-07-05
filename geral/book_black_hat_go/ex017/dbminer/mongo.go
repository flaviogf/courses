package dbminer

import (
	"context"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"go.mongodb.org/mongo-driver/mongo/readpref"
)

type MongoMiner struct {
}

func NewMongoMiner() *MongoMiner {
	return &MongoMiner{}
}

func (m *MongoMiner) GetSchema() (*Schema, error) {
	var result Schema

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	connectionString := "mongodb://root:example@localhost:27017/?authSource=admin"
	client, err := mongo.Connect(ctx, options.Client().ApplyURI(connectionString))

	if err != nil {
		return nil, err
	}

	if err = client.Ping(ctx, readpref.Primary()); err != nil {
		return nil, err
	}

	databaseNames, err := client.ListDatabaseNames(ctx, bson.D{{"name", bson.D{{"$ne", "config"}}}})

	if err != nil {
		return nil, err
	}

	for _, databaseName := range databaseNames {
		database := Database{Name: databaseName, Tables: []Table{}}

		collections, err := client.Database(databaseName).ListCollectionNames(ctx, bson.D{})

		if err != nil {
			return nil, err
		}

		for _, collection := range collections {
			table := Table{Name: collection, Columns: []string{}}

			var docRaw bson.Raw
			err = client.Database(databaseName).Collection(collection).FindOne(ctx, bson.D{}).Decode(&docRaw)

			if err != nil {
				return nil, err
			}

			database.Tables = append(database.Tables, table)
		}

		result.Databases = append(result.Databases, database)
	}

	log.Printf("%v\n", result)

	return &result, nil
}
