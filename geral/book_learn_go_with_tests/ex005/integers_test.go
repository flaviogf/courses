package integers

import (
	"fmt"
	"testing"
)

func TestAdd(t *testing.T) {
	got := Add(2, 2)
	want := 4

	if got != want {
		t.Errorf("got: %d, want: %d", got, want)
	}
}

func ExampleAdd() {
	fmt.Println(Add(3, 3))
	// Output: 6
}
