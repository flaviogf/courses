package viewmodels

import "github.com/flaviogf/webapp/models"

type ShopViewModel struct {
	Title      string
	Active     string
	Categories []CategoryViewModel
}

func NewShopViewModel(categories []models.Category) ShopViewModel {
	var categoriesViewModel []CategoryViewModel

	for _, it := range categories {
		categoriesViewModel = append(categoriesViewModel, NewCategoryViewModel(it))
	}

	return ShopViewModel{"Shop", "shop", categoriesViewModel}
}
