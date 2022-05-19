package main

import (
	"context"
	"fmt"
	"log"

	"cloud.google.com/go/bigtable"
)

func main() {
	project := "project"
	instance := "instance"
	tableName := "hello-world"
	columnFamily := "cf1"
	columnName := "greeting"
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

	tbl := client.Open(tableName)

	muts := make([]*bigtable.Mutation, len(greetings))
	rowKeys := make([]string, len(greetings))

	for i, greeting := range greetings {
		muts[i] = bigtable.NewMutation()
		muts[i].Set(columnFamily, columnName, bigtable.Now(), []byte(greeting))
		rowKeys[i] = fmt.Sprintf("%s%d", columnName, i)
	}

	rowErrs, err := tbl.ApplyBulk(ctx, rowKeys, muts)

	if err != nil {
		log.Fatalf("Could not apply bulk row mutation: %v", err)
	}

	if rowErrs != nil {
		for _, rowErr := range rowErrs {
			log.Printf("Erro writing row: %v", rowErr)
		}

		log.Fatal("Could not write some rows\n")
	}

	log.Println("Getting a single greeting by row key")

	row, err := tbl.ReadRow(ctx, rowKeys[0], bigtable.RowFilter(bigtable.ColumnFilter(columnName)))

	if err != nil {
		log.Fatalf("Could not read row with key %s: %v", rowKeys[0], err)
	}

	log.Printf("\t%s: %s", rowKeys[0], string(row[columnFamily][0].Value))

	err = tbl.ReadRows(ctx, bigtable.PrefixRange(columnName), func(row bigtable.Row) bool {
		item := row[columnFamily][0]
		log.Printf("\t%s: %s\n", item.Row, string(item.Value))
		return true
	}, bigtable.RowFilter(bigtable.ColumnFilter(columnName)))
}

func sliceContains(tables []string, tableName string) bool {
	for _, table := range tables {
		if table == tableName {
			return true
		}
	}

	return false
}
