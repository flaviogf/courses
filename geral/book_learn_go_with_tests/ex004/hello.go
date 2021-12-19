package main

import "fmt"

func main() {
	fmt.Println(Hello("", ""))
	fmt.Println(Hello("Frank", ""))
	fmt.Println(Hello("Frank", "Spanish"))
}

var prefixes = map[string]string{
	"English": "Hello, ",
	"Spanish": "Hola, ",
}

func Hello(name, language string) string {
	prefix := getPrefix(language)

	if name != "" {
		return prefix + name
	}

	return prefix + "world"
}

func getPrefix(language string) string {
	if language == "" {
		language = "English"
	}

	return prefixes[language]
}
