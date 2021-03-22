package main

import (
	"fmt"
	"log"

	"github.com/flaviogf/datatypes/organization"
)

func main() {
	frank := organization.NewPerson("Frank", "Castle", organization.NewEuropeanUnionNumber("123", "England"))

	fmt.Println(frank.ID())

	fmt.Println(frank.Country())

	fmt.Println(frank.FullName())

	err := frank.SetTwitter("@frankcastle")

	if err != nil {
		log.Fatal(err)
	}

	fmt.Println(frank.Twitter())

	fmt.Println(frank.Twitter().RedirectUrl())

	usa := organization.NewSocialSecurityNumber("123")

	eu := organization.NewEuropeanUnionNumber("123", "United State of America")

	fmt.Printf("%s %s\n", usa.ID(), usa.Country())

	fmt.Printf("%s %s\n", eu.ID(), eu.Country())

	if usa == eu {
		fmt.Println("We matched")
	} else {
		fmt.Println("We did not match")
	}
}
