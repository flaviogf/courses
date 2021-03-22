package main

import (
	"fmt"
	"log"

	"github.com/flaviogf/datatypes/organization"
)

func main() {
	frank := organization.NewPerson("Frank", "Castle", organization.NewSocialSecurityNumber("123"))

	fmt.Println(frank.ID())

	fmt.Println(frank.FullName())

	err := frank.SetTwitter("@frankcastle")

	if err != nil {
		log.Fatal(err)
	}

	fmt.Println(frank.Twitter())

	fmt.Println(frank.Twitter().RedirectUrl())
}
