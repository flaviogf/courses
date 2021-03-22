package organization

import (
	"fmt"
	"strings"
)

type Identifiable interface {
	ID() string
}

type Person struct {
	firstName string
	lastName  string
	twitter   string
}

func NewPerson(firstName, lastName string) *Person {
	return &Person{firstName: firstName, lastName: lastName}
}

func (p *Person) ID() string {
	return "12345"
}

func (p *Person) FullName() string {
	return fmt.Sprintf("%s %s", p.firstName, p.lastName)
}

func (p *Person) SetTwitter(twitter string) error {
	if strings.HasPrefix(twitter, "@") {
		p.twitter = twitter

		return nil
	}

	return fmt.Errorf("%s is not a valid argument", twitter)
}

func (p *Person) Twitter() string {
	return p.twitter
}
