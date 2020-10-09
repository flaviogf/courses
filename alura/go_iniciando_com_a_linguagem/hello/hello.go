package main

import (
	"bufio"
	"fmt"
	"net/http"
	"os"
	"time"
)

const monitors = 5

const delay = 5

func main() {
	urls := []string{"https://alura.com.br", "https://caelum.com.br", "https://random-status-code.herokuapp.com"}

	showPresentation("Frank", 1.1)

	readFile()

	for {
		fmt.Println("1- Begin monitoring")
		fmt.Println("2- Show logs")
		fmt.Println("0- Exit")

		option := readOption()

		switch option {
		case 1:
			beginMonitor(urls)
		case 2:
			fmt.Println("Displaying logs...")
		case 0:
			fmt.Println("Exiting...")
			os.Exit(0)
		default:
			fmt.Println("Command wasn't recognized")
			os.Exit(-1)
		}
	}
}

func showPresentation(name string, version float64) {
	fmt.Println("Hello ", name)
	fmt.Println("This application is version ", version)
}

func readOption() int {
	var result int
	fmt.Scan(&result)
	return result
}

func beginMonitor(urls []string) {
	fmt.Println("Monitoring...")

	for i := 0; i < monitors; i++ {
		for _, url := range urls {
			monitor(url)
		}

		time.Sleep(delay * time.Second)
	}
}

func monitor(url string) {
	resp, _ := http.Get(url)

	if resp.StatusCode == 200 {
		fmt.Println("url: ", url, "is running 🚀")
		return
	}

	fmt.Println("url: ", url, "isn't available 🧨")
}

func readFile() {
	file, _ := os.Open("urls.txt")

	reader := bufio.NewReader(file)

	line, _, _ := reader.ReadLine()

	text := string(line)

	fmt.Println(text)
}
