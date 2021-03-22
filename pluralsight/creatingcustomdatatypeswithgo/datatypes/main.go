package main

import (
	"fmt"
	"log"

	"github.com/flaviogf/datatypes/organization"
)

func main() {
	frank := organization.NewPerson("Frank", "Castle")

	fmt.Println(frank.ID())

	fmt.Println(frank.FullName())

	err := frank.SetTwitter("@frankcastle")

	if err != nil {
		log.Fatal(err)
	}

	fmt.Println(frank.Twitter())
}
