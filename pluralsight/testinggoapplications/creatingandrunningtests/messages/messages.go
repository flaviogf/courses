package messages

import "fmt"

func Greet(name string) string {
	return fmt.Sprintf("Hello, %s!\n", name)
}

func depart(name string) string {
	return fmt.Sprintf("Goodbye, %s", name)
}
