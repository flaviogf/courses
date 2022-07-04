package main

import "gitub.com/flaviogf/courses/geral/book_black_hat_go/ex017/dbminer"

func main() {
	mongoMiner := dbminer.NewMongoMiner()
	dbminer.Search(mongoMiner)
}
