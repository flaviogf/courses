package main

import (
	"fmt"

	"github.com/flaviogf/bank/accounts"
)

func main() {
	account1 := accounts.Account{Holder: "Frank", Agency: "123", Number: "456789", Balance: 100}

	account2 := accounts.Account{Holder: "Nina", Agency: "321", Number: "987654", Balance: 0}

	account1.Transfer(50, &account2)

	fmt.Println(account1)

	fmt.Println(account2)
}
