package main

import "fmt"

func main() {
	fmt.Println(Hello("", ""))
	fmt.Println(Hello("Frank", ""))
	fmt.Println(Hello("Frank", "Spanish"))
	fmt.Println(Hello("Frank", "French"))
}

const defaultPrefix = "Hello, "

var prefixes = map[string]string{
	"Spanish": "Hola, ",
	"French":  "Bonjour, ",
}

func Hello(name, language string) string {
	prefix := getPrefix(language)

	if name != "" {
		return prefix + name
	}

	return prefix + "world"
}

func getPrefix(language string) string {
	prefix := prefixes[language]

	if prefix != "" {
		return prefix
	}

	return defaultPrefix
}
