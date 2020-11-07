package main

import (
	"encoding/json"
	"fmt"
)

type produto struct {
	ID    int      `json:"id"`
	Nome  string   `json:"nome"`
	Preco float64  `json:"preco"`
	Tags  []string `json:"tags"`
}

func main() {
	p1 := produto{1, "Notebook", 1899.90, []string{"Promoção", "Eletrônico"}}
	bytes, _ := json.Marshal(p1)
	fmt.Println(string(bytes))

	var p2 produto
	p2JSON := `{"id":1,"nome":"Notebook","preco":1899.9,"tags":["Promoção","Eletrônico"]}`
	json.Unmarshal([]byte(p2JSON), &p2)
	fmt.Println(p2)
}
