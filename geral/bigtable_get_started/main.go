package main

import (
	"context"
	"log"

	"cloud.google.com/go/bigtable"
)

func main() {
	project := "project"
	instance := "instance"
	tableName := "hello-world"

	ctx := context.Background()
	adminClient, err := bigtable.NewAdminClient(ctx, project, instance)

	if err != nil {
		log.Fatalf("Could not create admin client: %v\n", err)
	}

	tables, err := adminClient.Tables(ctx)

	if err != nil {
		log.Fatalf("Could not fetch table list: %v\n", err)
	}

	if !sliceContains(tables, tableName) {
		log.Printf("Creating table: %v\n", tableName)
	}
}

func sliceContains(tables []string, tableName string) bool {
	for _, table := range tables {
		if table == tableName {
			return true
		}
	}

	return false
}
