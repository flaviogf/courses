package account

import "errors"

type Account struct {
	Holder  string
	Agency  string
	Number  string
	Balance int
}

func (self *Account) Withdraw(value int) error {
	if value <= 0 {
		return errors.New("value to withdraw must be positive")
	}

	balance := self.Balance - value

	if balance < 0 {
		return errors.New("value to withdraw is not available")
	}

	self.Balance = balance

	return nil
}

func (self *Account) Deposit(value int) error {
	if value <= 0 {
		return errors.New("value to deposit must be positive")
	}

	self.Balance += value

	return nil
}

func (self *Account) Transfer(value int, target *Account) error {
	err := self.Withdraw(value)

	if err != nil {
		return err
	}

	err = target.Deposit(value)

	if err != nil {
		return err
	}

	return nil
}
