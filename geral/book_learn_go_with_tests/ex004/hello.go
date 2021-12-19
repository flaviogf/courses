package main

func main() {
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
