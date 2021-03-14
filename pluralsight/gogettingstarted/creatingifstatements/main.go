package main

import "fmt"

type User struct {
	ID        int
	FirstName string
	LastName  string
}

func (u User) Equal(other User) bool {
	return u.ID == other.ID
}

func (u User) Similiar(other User) bool {
	return u.FirstName == other.FirstName
}

func main() {
	u1 := User{
		ID:        1,
		FirstName: "Frank",
		LastName:  "Castle",
	}

	u2 := User{
		ID:        2,
		FirstName: "Frank",
		LastName:  "Parker",
	}

	if u1.Equal(u2) {
		fmt.Println("Same user")

		return
	}

	if u1.Similiar(u2) {
		fmt.Print("Similiar user")

		return
	}

	fmt.Println("Different user")
}
