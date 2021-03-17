package viewmodel

type IndexViewModel struct {
	Title  string
	Active string
}

func NewIndexViewModel() *IndexViewModel {
	return &IndexViewModel{"Home", "home"}
}
