package accounts

import (
	"errors"

	"github.com/flaviogf/bank/customers"
)

type Account struct {
	Holder  customers.Customer
	Agency  string
	Number  string
	balance int
}

func (self *Account) Deposit(value int) error {
	if value <= 0 {
		return errors.New("value to deposit must be positive")
	}

	self.balance += value

	return nil
}

func (self *Account) Balance() int {
	return self.balance
}
