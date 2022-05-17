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
	columnFamily := "cf1"
	greetings := []string{"Hello world!", "Hello Cloud Bigtable", "Hello golang!"}

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
		log.Printf("Creating table: %s\n", tableName)

		err = adminClient.CreateTable(ctx, tableName)

		if err != nil {
			log.Fatalf("Could not create table %s: %v\n", tableName, err)
		}
	}

	tblInfo, err := adminClient.TableInfo(ctx, tableName)

	if err != nil {
		log.Fatalf("Could not read info for table %s: %v\n", tableName, err)
	}

	if !sliceContains(tblInfo.Families, columnFamily) {
		if err := adminClient.CreateColumnFamily(ctx, tableName, columnFamily); err != nil {
			log.Fatalf("Could not create column family %s: %v\n", columnFamily, err)
		}
	}

	client, err := bigtable.NewClient(ctx, project, instance)

	if err != nil {
		log.Fatalf("Could not create data operation client: %v\n", err)
	}

	client.Open(tableName)

	log.Println(greetings)
}

func sliceContains(tables []string, tableName string) bool {
	for _, table := range tables {
		if table == tableName {
			return true
		}
	}

	return false
}
