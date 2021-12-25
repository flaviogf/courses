package wallet

import "testing"

func TestWallet(t *testing.T) {
	t.Run("Deposit", func(t *testing.T) {
		wallet := Wallet{}
		wallet.Deposit(Bitcoin(100))

		got := wallet.Balance()
		want := Bitcoin(100)

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	})

	t.Run("Withdraw", func(t *testing.T) {
		wallet := Wallet{Bitcoin(100)}
		wallet.Withdraw(Bitcoin(50))

		got := wallet.Balance()
		want := Bitcoin(50)

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	})
}
