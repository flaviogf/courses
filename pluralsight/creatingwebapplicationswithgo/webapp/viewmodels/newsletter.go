package viewmodels

type NewsletterViewModel struct {
	Title  string
	Active string
}

func NewNewsletterViewModel() NewsletterViewModel {
	return NewsletterViewModel{"Newsletter", "newsletter"}
}
