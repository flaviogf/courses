package dictionary

import "testing"

func TestAdd(t *testing.T) {
	dictionary := Dictionary{}
	err := dictionary.Add("test", "it is a simple test")
	got, _ := dictionary.Search("test")

	assertNoError(t, err)
	assertDefinition(t, got, "it is a simple test")

	t.Run("when the word already exists", func(t *testing.T) {
		dictionary := Dictionary{"test": "it is a simple test"}
		err := dictionary.Add("test", "it will not work")
		got, _ := dictionary.Search("test")

		assertError(t, err, ErrWordExists)
		assertDefinition(t, got, "it is a simple test")
	})
}

func TestSearch(t *testing.T) {
	dictionary := Dictionary{"test": "it is a simple test"}
	got, _ := dictionary.Search("test")

	assertDefinition(t, got, "it is a simple test")

	t.Run("when the word does not exist", func(t *testing.T) {
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
		t.Error("did not get an error but wanted one")
	}

	if got != want {
		t.Errorf("got: %q, want: %q", got, want)
	}
}

func assertNoError(t testing.TB, got error) {
	if got != nil {
		t.Errorf("got an error but did not want one")
	}
}
