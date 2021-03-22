package organization

import (
	"fmt"
	"strings"
)

type Identifiable interface {
	ID() string
}

type Citizen interface {
	Identifiable
	Country() string
}

type socialSecurityNumber string

func NewSocialSecurityNumber(value string) Citizen {
	return socialSecurityNumber(value)
}

func (s socialSecurityNumber) ID() string {
	return string(s)
}

func (s socialSecurityNumber) Country() string {
	return "United State of America"
}

type europeanUnionNumber struct {
	id      string
	country string
}

func NewEuropeanUnionNumber(id, country string) Citizen {
	return europeanUnionNumber{id, country}
}

func (e europeanUnionNumber) ID() string {
	return e.id
}

func (e europeanUnionNumber) Country() string {
	return e.country
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
	Citizen
	twitter Twitter
}

func NewPerson(firstName, lastName string, citizen Citizen) *Person {
	return &Person{
		Name: Name{
			firstName,
			lastName,
		},
		Citizen: citizen,
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
