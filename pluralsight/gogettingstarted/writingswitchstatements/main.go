package main

import "fmt"

type HTTPMethod int

const (
	GET HTTPMethod = iota
	POST
	DELETE
	PUT
)

type HTTPRequest struct {
	Method HTTPMethod
}

func main() {
	r := HTTPRequest{GET}

	switch r.Method {
	case GET:
		fmt.Println("Get method")
	case POST:
		fmt.Println("Post method")
	case DELETE:
		fmt.Println("Delete method")
	case PUT:
		fmt.Println("Put method")
	default:
		fmt.Println("Unhandled method")
	}
}
