package wallet

import "testing"

func TestDeposit(t *testing.T) {
	wallet := Wallet{}
	wallet.Deposit(Bitcoin(100))

	got := wallet.Balance()
	want := Bitcoin(100)

	if got != want {
		t.Errorf("got: %d, want: %d", got, want)
	}
}
