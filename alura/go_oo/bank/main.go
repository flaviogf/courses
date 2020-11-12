package main

import "fmt"

type Account struct {
	Holder  string
	Agency  string
	Number  string
	Balance int
}

func main() {
	account := Account{
		"Frank",
		"123",
		"456",
		9999,
	}

	fmt.Printf("%s %s %s %dc\n", account.Holder, account.Agency, account.Number, account.Balance)
}
