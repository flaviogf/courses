package main

import (
	"log"

	"github.com/flaviogf/courses/geral/book_black_hat_go/ex018/dbminer"
)

func main() {
	pm := dbminer.NewPostgreSQLMiner()

	if err := dbminer.Search(pm); err != nil {
		log.Fatalln(err)
	}
}
