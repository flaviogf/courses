package models

import (
	"errors"
	"fmt"
)

type User struct {
	ID        int
	FirstName string
	LastName  string
}

var (
	users  []*User
	nextID = 1
)

func GetUsers() []*User {
	return users
}

func AddUser(user User) (User, error) {
	if user.ID != 0 {
		return User{}, errors.New("User id must be empty")
	}

	user.ID = nextID

	nextID++

	users = append(users, &user)

	return user, nil
}

func GetUserById(id int) (User, error) {
	for _, it := range users {
		if it.ID == id {
			return *it, nil
		}
	}

	return User{}, fmt.Errorf("User with id '%v' was not found", id)
}

func UpdateUser(user User) (User, error) {
	for index, it := range users {
		if it.ID == user.ID {
			users[index] = &user

			return user, nil
		}
	}

	return User{}, fmt.Errorf("User with id '%v' was not found", user.ID)
}

func RemoveUserById(id int) error {
	for index, it := range users {
		if it.ID == id {
			users = append(users[:index], users[index+1:]...)

			return nil
		}
	}

	return fmt.Errorf("User with id '%v' was not found", id)
}
