package main

import "fmt"

type Account struct {
	Holder  string
	Agency  string
	Number  string
	Balance int
}

func main() {
	first := Account{"Frank", "000", "0000", 999}

	fmt.Println(first)

	second := new(Account)
	second.Holder = "Frank"
	second.Agency = "000"
	second.Number = "0000"
	second.Balance = 999

	fmt.Println(second)

	fmt.Println(first == *second)
}
