package main

import (
	"fmt"

	"github.com/flaviogf/webservice/models"
)

func main() {
	frank := models.User{
		ID:        1,
		FirstName: "Frank",
		LastName:  "Castle",
	}

	fmt.Println(frank)
}
