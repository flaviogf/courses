package greetings

import (
	"errors"
	"fmt"
	"math/rand"
	"time"
)

// Hello returns a greeting for the named person.
func Hello(name string) (string, error) {
	// If no name was given, return an error with a message.
	if name == "" {
		return "", errors.New("empty name")
	}

	// If a name was received, return a value that embeds the name
	// in a greeting message.
	return fmt.Sprintf(randomFormat(), name), nil
}

func init() {
	rand.Seed(time.Now().UnixNano())
}

func randomFormat() string {
	formats := []string{
		"Hi, %s. Welcome!",
		"Great to see you, %s!",
		"Hail, %s! Well met!",
	}

	return formats[rand.Intn(len(formats))]
}
