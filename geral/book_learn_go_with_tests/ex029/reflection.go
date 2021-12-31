package main

import "reflect"

func Walk(v interface{}, fn func(string)) {
	value := reflect.ValueOf(v)

	for i := 0; i < value.NumField(); i++ {
		field := value.Field(i)
		fn(field.String())
	}
}
