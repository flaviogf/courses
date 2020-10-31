package db

import (
	"os"

	"github.com/go-redis/redis/v8"
)

func Connect() *redis.Client {
	client := redis.NewClient(&redis.Options{
		Addr:     os.Getenv("REDIS_URL"),
		Password: "",
		DB:       0,
	})

	return client
}
