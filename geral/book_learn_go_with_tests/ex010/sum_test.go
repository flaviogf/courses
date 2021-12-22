package sum

import "testing"

func TestSum(t *testing.T) {
	got := Sum([]int{1, 2, 3, 4, 5})
	want := 15

	if got != want {
		t.Errorf("got: %d, want: %d", got, want)
	}
}
