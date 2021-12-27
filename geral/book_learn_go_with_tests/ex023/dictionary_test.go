package dictionary

import "testing"

func TestAdd(t *testing.T) {
	dictionary := Dictionary{}
	dictionary.Add("test", "it is just a test")
	got, _ := dictionary.Search("test")
	assertDefinition(t, got, "it is just a test")
}

func TestSearch(t *testing.T) {
	dictionary := Dictionary{"test": "it is just a test"}
	got, _ := dictionary.Search("test")
	assertDefinition(t, got, "it is just a test")

	t.Run("when word does not exist", func(t *testing.T) {
		dictionary := Dictionary{}
		_, err := dictionary.Search("test")
		assertError(t, err, ErrNotFound)
	})
}

func assertDefinition(t testing.TB, got, want string) {
	t.Helper()

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}

func assertError(t testing.TB, got, want error) {
	t.Helper()

	if got == nil {
		t.Fatal("did not get an error but wanted one")
	}

	if got != want {
		t.Errorf("got: %q, want: %q", got, want)
	}
}
