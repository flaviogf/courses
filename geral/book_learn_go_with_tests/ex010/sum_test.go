package sum

import (
	"reflect"
	"testing"
)

func TestSumAllTails(t *testing.T) {
	checkSum := func(t testing.TB, got, want []int) {
		t.Helper()

		if !reflect.DeepEqual(got, want) {
			t.Errorf("got: %v, want: %v", got, want)
		}
	}

	got := SumAllTails([]int{1, 2}, []int{0, 9})
	want := []int{2, 9}
	checkSum(t, got, want)

	t.Run("with an empty slice", func(t *testing.T) {
		got := SumAllTails([]int{})
		want := []int{0}
		checkSum(t, got, want)
	})
}

func TestSumAll(t *testing.T) {
	got := SumAll([]int{1, 2}, []int{0, 9})
	want := []int{3, 9}

	if !reflect.DeepEqual(got, want) {
		t.Errorf("got: %v, want: %v", got, want)
	}
}

func TestSum(t *testing.T) {
	got := Sum([]int{1, 2, 3, 4, 5})
	want := 15

	if got != want {
		t.Errorf("got: %d, want: %d", got, want)
	}
}
