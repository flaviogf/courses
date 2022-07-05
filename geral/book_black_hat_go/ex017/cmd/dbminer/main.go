package main

import (
	"log"

	"gitub.com/flaviogf/courses/geral/book_black_hat_go/ex017/dbminer"
)

func main() {
	mongoMiner := dbminer.NewMongoMiner()

	if err := dbminer.Search(mongoMiner); err != nil {
		log.Fatalln(err)
	}
}
