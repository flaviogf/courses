package dictionary

import "testing"

func TestAdd(t *testing.T) {
	dictionary := Dictionary{}
	dictionary.Add("test", "it is just a test")
	got, _ := dictionary.Search("test")
	assertDefinition(t, got, "it is just a test")

	t.Run("when word already exists", func(t *testing.T) {
		dictionary := Dictionary{"test": "it is just a test"}
		err := dictionary.Add("test", "it will not work")
		got, _ := dictionary.Search("test")
		assertError(t, err, ErrWordExists)
		assertDefinition(t, got, "it is just a test")
	})
}

func TestUpdate(t *testing.T) {
	dictionary := Dictionary{"test": "it is just a test"}
	dictionary.Update("test", "it works")
	got, _ := dictionary.Search("test")
	assertDefinition(t, got, "it works")
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
