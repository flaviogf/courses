package main

import (
	"fmt"
	"net/http"
)

func main() {
	showPresentation("Frank", 1.1)

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
	default:
		fmt.Println("Command wasn't recognized")
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
	url := "https://www.alura.com.br"
	resp, _ := http.Get(url)
	fmt.Println(resp)
}
