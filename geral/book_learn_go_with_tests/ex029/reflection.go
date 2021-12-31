package main

import "reflect"

func Walk(v interface{}, fn func(string)) {
	value := reflect.ValueOf(v)
	field := value.Field(0)
	fn(field.String())
}
