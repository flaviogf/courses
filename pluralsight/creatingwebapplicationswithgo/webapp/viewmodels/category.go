package viewmodels

import "github.com/flaviogf/webapp/models"

type CategoryViewModel struct {
	Title       string
	Active      string
	ID          int
	Name        string
	Description string
}

func NewCategoryViewModel(category models.Category) CategoryViewModel {
	return CategoryViewModel{"Shop", "shop", category.ID, category.Name, category.Description}
}
