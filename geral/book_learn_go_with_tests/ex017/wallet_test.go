package wallet

import "testing"

func TestWallet(t *testing.T) {
	assertBalance := func(t testing.TB, wallet *Wallet, want Bitcoin) {
		t.Helper()

		got := wallet.Balance()

		if got != want {
			t.Errorf("got: %s, want: %s", got, want)
		}
	}

	t.Run("Deposit", func(t *testing.T) {
		wallet := Wallet{}
		wallet.Deposit(Bitcoin(100))

		assertBalance(t, &wallet, Bitcoin(100))
	})

	t.Run("Withdraw", func(t *testing.T) {
		wallet := Wallet{Bitcoin(100)}
		wallet.Withdraw(Bitcoin(50))

		assertBalance(t, &wallet, Bitcoin(50))
	})
}
