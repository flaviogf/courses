package main

import (
	"gitub.com/flaviogf/courses/geral/book_black_hat_go/ex017/dbminer"
)

type MongoMiner struct {
}

func NewMongoMiner() *MongoMiner {
	return &MongoMiner{}
}

func (m *MongoMiner) GetSchema() (*dbminer.Schema, error) {
	var result dbminer.Schema

	return &result, nil
}

func main() {
	mongoMiner := NewMongoMiner()
	dbminer.Search(mongoMiner)
}
