package main

import (
	"errors"
	"fmt"
	"log"
)

type Account struct {
	Holder  string
	Agency  string
	Number  string
	Balance int
}

func (self *Account) Withdraw(value int) error {
	hasNoBalance := self.Balance-value < 0

	if hasNoBalance {
		return errors.New("Value is not available")
	}

	self.Balance -= value

	return nil
}

func main() {
	account := Account{"Frank", "123", "456789", 999}

	fmt.Println(account)

	err := account.Withdraw(500)

	if err != nil {
		log.Fatalf("Something goes wrong! Detail: %s", err.Error())
	}

	err = account.Withdraw(500)

	if err != nil {
		log.Fatalf("Something goes wrong! Detail: %s", err.Error())
	}
}
