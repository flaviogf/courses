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

func (self *Account) Deposit(value int) error {
	if value <= 0 {
		return errors.New("value to deposit must be greater than 0")
	}

	self.Balance += value

	return nil
}

func (self *Account) Withdraw(value int) error {
	if value <= 0 {
		return errors.New("value to withdraw must be greater than 0")
	}

	hasNoBalance := self.Balance-value < 0

	if hasNoBalance {
		return errors.New("value to withdraw is not available")
	}

	self.Balance -= value

	return nil
}

func main() {
	account := Account{"Frank", "123", "456789", 999}

	fmt.Println(account)

	err := account.Withdraw(500)

	if err != nil {
		log.Println(err.Error())
	}

	err = account.Withdraw(500)

	if err != nil {
		log.Println(err.Error())
	}

	err = account.Deposit(100)

	if err != nil {
		log.Println(err.Error())
	}

	fmt.Println(account)
}
