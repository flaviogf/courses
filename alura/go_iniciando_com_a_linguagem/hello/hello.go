package main

import (
	"fmt"
	"net/http"
	"os"
)

func main() {
	showPresentation("Frank", 1.1)

	for {
		fmt.Println("1- Begin monitoring")
		fmt.Println("2- Show logs")
		fmt.Println("0- Exit")

		option := readOption()

		switch option {
		case 1:
			beginMonitoring()
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

func beginMonitoring() {
	fmt.Println("Monitoring...")
	url := "http://random-status-code.herokuapp.com/"
	resp, _ := http.Get(url)

	if resp.StatusCode == 200 {
		fmt.Println("website: ", url, "is running 🚀")
		return
	}

	fmt.Println("website: ", url, "isn't available 🧨")
}
