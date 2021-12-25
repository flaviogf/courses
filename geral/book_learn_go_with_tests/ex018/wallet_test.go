package wallet

import "testing"

func TestWallet(t *testing.T) {
	t.Run("Deposit", func(t *testing.T) {
		wallet := Wallet{}
		wallet.Deposit(Bitcoin(100))

		assertBalance(t, &wallet, Bitcoin(100))
	})

	t.Run("Withdraw", func(t *testing.T) {
		wallet := Wallet{Bitcoin(100)}
		err := wallet.Withdraw(Bitcoin(50))

		assertNoError(t, err)
		assertBalance(t, &wallet, Bitcoin(50))
	})

	t.Run("Withdraw with no funds", func(t *testing.T) {
		wallet := Wallet{}
		err := wallet.Withdraw(Bitcoin(100))

		assertError(t, err, ErrInsufficientFunds)
		assertBalance(t, &wallet, Bitcoin(0))
	})
}

func assertBalance(t testing.TB, wallet *Wallet, want Bitcoin) {
	t.Helper()

	got := wallet.Balance()

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}

func assertError(t testing.TB, got, want error) {
	t.Helper()

	if got == nil {
		t.Fatal("didn't get an error, but wanted one")
	}

	if got != want {
		t.Errorf("got: %v, want: %v", got, want)
	}
}

func assertNoError(t testing.TB, got error) {
	t.Helper()

	if got != nil {
		t.Errorf("didn't want an error, but got one")
	}
}
