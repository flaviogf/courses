package main

type Checker interface {
	Check(url string) bool
}

func CheckWebsites(c Checker, urls []string) map[string]bool {
	result := make(map[string]bool)

	for _, url := range urls {
		result[url] = c.Check(url)
	}

	return result
}
