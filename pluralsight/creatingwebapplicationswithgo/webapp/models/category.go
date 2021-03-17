package models

import (
	"encoding/json"
	"errors"
	"io/ioutil"
	"os"
)

type Category struct {
	ID          int
	Name        string
	Description string
}

func GetCategory(id int) (Category, error) {
	categories, err := GetCategories()

	if err != nil {
		return Category{}, err
	}

	for _, it := range categories {
		if it.ID == id {
			return it, nil
		}
	}

	return Category{}, errors.New("Category not found")
}

func GetCategories() ([]Category, error) {
	var categories []Category

	file, err := os.Open("categories.json")

	if err != nil {
		return categories, err
	}

	bytes, err := ioutil.ReadAll(file)

	if err != nil {
		return categories, err
	}

	json.Unmarshal(bytes, &categories)

	return categories, nil
}
