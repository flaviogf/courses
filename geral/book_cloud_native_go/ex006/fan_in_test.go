package main

import (
	"reflect"
	"testing"
)

func TestFanIn(t *testing.T) {
	channels := []chan int{}

	for i := 0; i < 5; i++ {
		channel := make(chan int)

		go func(i int) {
			defer close(channel)

			channel <- i
		}(i)

		channels = append(channels, channel)
	}

	results := []int{}

	for i := range FanIn(channels) {
		results = append(results, i)
	}

	expectedResults := []int{0, 1, 2, 3, 4}

	if !reflect.DeepEqual(results, expectedResults) {
		t.Errorf("got: %v, want: %v", results, expectedResults)
	}
}
