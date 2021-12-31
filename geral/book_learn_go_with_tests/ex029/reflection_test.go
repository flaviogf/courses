package main

import (
	"reflect"
	"testing"
)

func TestWalk(t *testing.T) {
	testCases := []struct {
		Name          string
		Input         interface{}
		ExpectedCalls []string
	}{
		{
			Name:          "when struct has only one field",
			Input:         struct{ Name string }{"Chris"},
			ExpectedCalls: []string{"Chris"},
		},
	}

	for _, test := range testCases {
		t.Run(test.Name, func(t *testing.T) {
			got := []string{}

			Walk(test.Input, func(value string) {
				got = append(got, value)
			})

			if !reflect.DeepEqual(got, test.ExpectedCalls) {
				t.Errorf("got: %v, want: %v", got, test.ExpectedCalls)
			}
		})
	}
}
