package main

import (
	"fmt"

	"github.com/flaviogf/bank/accounts"
)

func main() {
	exec(accounts.Create("checking"))
	exec(accounts.Create("savings"))
}

func exec(account accounts.Account) {
	for i := 0; i < 5; i++ {
		account.Deposit(100)

		fmt.Println(account.Balance())
	}
}
