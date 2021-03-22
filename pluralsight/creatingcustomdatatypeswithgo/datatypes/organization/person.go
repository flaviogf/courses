package organization

import (
	"fmt"
	"strings"
)

type Identifiable interface {
	ID() string
}

type socialSecurityNumber string

func NewSocialSecurityNumber(value string) Identifiable {
	return socialSecurityNumber(value)
}

func (s socialSecurityNumber) ID() string {
	return string(s)
}

type Name struct {
	first string
	last  string
}

func (n *Name) FullName() string {
	return fmt.Sprintf("%s %s", n.first, n.last)
}

type Twitter string

func (t Twitter) RedirectUrl() string {
	return fmt.Sprintf("https://twitter.com/%s", strings.Replace(string(t), "@", "", -1))
}

func (t Twitter) IsNotValid() bool {
	return !strings.HasPrefix(string(t), "@")
}

type Person struct {
	Name
	Identifiable
	twitter Twitter
}

func NewPerson(firstName, lastName string, identifiable Identifiable) *Person {
	return &Person{
		Name: Name{
			firstName,
			lastName,
		},
		Identifiable: identifiable,
	}
}

func (p *Person) SetTwitter(twitter Twitter) error {
	if twitter.IsNotValid() {
		err := fmt.Errorf("%s is not a valid argument", twitter)

		return err
	}

	p.twitter = twitter

	return nil
}

func (p *Person) Twitter() Twitter {
	return p.twitter
}
