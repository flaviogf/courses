package main

import (
	"fmt"

	"github.com/flaviogf/bank/accounts"
	"github.com/flaviogf/bank/customers"
)

func main() {
	customer := customers.Customer{Name: "Frank", Document: "123.123.123-12", Job: "Developer"}

	account := accounts.Account{Holder: customer, Agency: "123", Number: "456789"}

	account.Deposit(100)

	fmt.Printf("Account: %v\tBalance: %d\n", account, account.Balance())
}
