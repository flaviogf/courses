package dictionary

import "testing"

func TestSearch(t *testing.T) {
	dictionary := map[string]string{"test": "it is just a simple test"}

	got := Search(dictionary, "test")
	want := "it is just a simple test"

	if got != want {
		t.Errorf("got: %s, want: %s", got, want)
	}
}
