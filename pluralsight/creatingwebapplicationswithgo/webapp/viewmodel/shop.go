package viewmodel

type ShopViewModel struct {
	Title      string
	Active     string
	Categories []CategoryViewModel
}

type CategoryViewModel struct {
	Name        string
	Description string
}

func NewShopViewModel(categories []CategoryViewModel) *ShopViewModel {
	return &ShopViewModel{"Shop", "shop", categories}
}
