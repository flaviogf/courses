package account

import (
	"errors"
	"testing"
)

func Test_Withdraw_Should_Withdraw_Value(t *testing.T) {
	account := Account{"Frank", "123", "456789", 100}

	account.Withdraw(100)

	if account.Balance != 0 {
		t.Errorf("expected: %v current: %v", 0, account.Balance)
	}
}

func Test_Withdraw_Should_Return_An_Error_When_The_Value_To_Withdraw_Is_Negative(t *testing.T) {
	account := Account{"Frank", "123", "456789", 100}

	err := account.Withdraw(-100)

	if err == nil {
		t.Errorf("expected: %v current: %v", errors.New("value to withdraw must be positive"), err)
	}
}

func Test_Withdraw_Should_Return_An_Error_When_The_Value_To_Withdraw_Is_Not_Available(t *testing.T) {
	account := Account{"Frank", "123", "456789", 100}

	err := account.Withdraw(200)

	if err == nil {
		t.Errorf("expected: %v current: %v", errors.New("value to withdraw is not available"), err)
	}
}

func Test_Deposit_Should_Deposit_Value(t *testing.T) {
	account := Account{"Frank", "123", "456789", 100}

	account.Deposit(100)

	if account.Balance != 200 {
		t.Errorf("expected: %v current: %v", 200, account.Balance)
	}
}

func Test_Deposit_Should_Return_An_Error_When_The_Value_To_Deposit_Is_Negative(t *testing.T) {
	account := Account{"Frank", "123", "456789", 100}

	err := account.Deposit(-100)

	if err == nil {
		t.Errorf("expected: %v current: %v", errors.New("value to deposit must be positive"), err)
	}
}

func Test_Transfer_Should_Transfer_Value(t *testing.T) {
	account1 := Account{"Frank", "123", "456789", 100}

	account2 := Account{"Nina", "321", "987654", 0}

	account1.Transfer(100, &account2)

	if account1.Balance != 0 {
		t.Errorf("expected: %v current: %v", 0, account1.Balance)
	}

	if account2.Balance != 100 {
		t.Errorf("expected: %v current: %v", 100, account2.Balance)
	}
}

func Test_Transfer_Should_Return_An_Error_When_The_Value_To_Transfer_Is_Negative(t *testing.T) {
	account1 := Account{"Frank", "123", "456789", 100}

	account2 := Account{"Nina", "321", "987654", 0}

	err := account1.Transfer(-100, &account2)

	if err == nil {
		t.Errorf("expected: %v current: %v", errors.New("value to withdraw must be positive"), err)
	}
}

func Test_Transfer_Should_Return_An_Error_When_The_Value_To_Transfer_Is_Not_Available(t *testing.T) {
	account1 := Account{"Frank", "123", "456789", 100}

	account2 := Account{"Nina", "321", "987654", 0}

	err := account1.Transfer(200, &account2)

	if err == nil {
		t.Errorf("expected: %v current: %v", errors.New("value to withdraw is not available"), err)
	}
}
