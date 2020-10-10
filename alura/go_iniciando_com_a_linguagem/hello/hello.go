package main

import (
	"bufio"
	"fmt"
	"io"
	"net/http"
	"os"
	"strconv"
	"time"
)

const monitors = 5

const delay = 5

func main() {
	showPresentation("Frank", 1.1)

	urls := readFile()

	fmt.Println(urls)

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
	resp, err := http.Get(url)

	if err != nil {
		text := "url: " + url + " isn't available 🧨"

		fmt.Println(text)

		registerLog(text, false)

		return
	}

	if resp.StatusCode != 200 {
		text := "url: " + url + " isn't available 🧨"

		fmt.Println(text)

		registerLog(text, false)

		return
	}

	text := "url: " + url + " is running 🚀"

	fmt.Println(text)

	registerLog(text, true)
}

func readFile() []string {
	file, _ := os.Open("urls.txt")

	reader := bufio.NewReader(file)

	var urls []string

	for {
		line, _, err := reader.ReadLine()

		if err == io.EOF {
			break
		}

		url := string(line)

		urls = append(urls, url)
	}

	file.Close()

	return urls
}

func registerLog(text string, online bool) {
	file, _ := os.OpenFile("log.txt", os.O_RDWR|os.O_CREATE|os.O_APPEND, 0666)

	file.WriteString(text + " online: " + strconv.FormatBool(online) + "\n")

	file.Close()
}
