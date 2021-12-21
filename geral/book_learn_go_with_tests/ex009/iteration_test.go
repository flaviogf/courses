package iteration

import "testing"

func TestSum(t *testing.T) {
	given := []int{1, 2, 3, 4, 5}
	got := Sum(given)
	want := 15

	if got != want {
		t.Errorf("got: %d, want: %d, given: %v", got, want, given)
	}
}
