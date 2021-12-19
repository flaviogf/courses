package main

func Hello(name string) string {
	if name != "" {
		return "Hello, " + name
	}

	return "Hello, world"
}
