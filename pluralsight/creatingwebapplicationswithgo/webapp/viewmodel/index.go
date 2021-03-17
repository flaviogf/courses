package viewmodel

type IndexViewModel struct {
	Title string
}

func NewIndexViewModel() *IndexViewModel {
	return &IndexViewModel{Title: "Home"}
}
