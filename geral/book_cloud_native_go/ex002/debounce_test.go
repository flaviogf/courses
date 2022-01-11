package main

import (
	"context"
	"fmt"
	"reflect"
	"testing"
	"time"
)

func TestDebounce(t *testing.T) {
	n := 0

	doubleCircuit := func(ctx context.Context) (string, error) {
		n++
		return fmt.Sprintf("%d", n), nil
	}

	debounce := Debounce(doubleCircuit, 1*time.Second)

	results := []string{}
	results = append(results, execute(t, debounce, 5)...)
	time.Sleep(1 * time.Second)
	results = append(results, execute(t, debounce, 5)...)

	expectedResults := []string{
		"1",
		"1",
		"1",
		"1",
		"1",
		"2",
		"2",
		"2",
		"2",
		"2",
	}

	if !reflect.DeepEqual(results, expectedResults) {
		t.Errorf("want: %v, got: %v", expectedResults, results)
	}
}

func execute(t testing.TB, debounce func(context.Context) (string, error), times int) []string {
	results := []string{}

	for i := 0; i < times; i++ {
		resp, err := debounce(context.TODO())

		if err != nil {
			t.Errorf("#%d error: %v", i+1, err)
		}

		results = append(results, resp)
	}

	return results
}
