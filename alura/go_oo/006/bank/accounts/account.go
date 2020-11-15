package accounts

import (
	"errors"
)

type Account interface {
	Deposit(value int) error
	Balance() int
}

type CheckingAccount struct {
	Agency  string
	Number  string
	balance int
}

type SavingsAccount struct {
	Agency  string
	Number  string
	balance int
}

func Create(key string) Account {
	switch key {
	case "checking":
		return &CheckingAccount{}
	case "savings":
		return &SavingsAccount{}
	default:
		return nil
	}
}

func (self *CheckingAccount) Deposit(value int) error {
	if value <= 0 {
		return errors.New("value to deposit must be positive")
	}

	self.balance += value

	return nil
}

func (self CheckingAccount) Balance() int {
	return self.balance
}

func (self *SavingsAccount) Deposit(value int) error {
	if value <= 0 {
		return errors.New("value to deposit must be positive")
	}

	self.balance = int(float64(self.balance)*1.05) + value

	return nil
}

func (self SavingsAccount) Balance() int {
	return self.balance
}
