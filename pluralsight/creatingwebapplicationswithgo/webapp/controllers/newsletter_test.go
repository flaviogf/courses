package controllers

import (
	"html/template"
	"net/http"
	"net/http/httptest"
	"testing"
)

func TestGetReturnsStatusCodeOk(t *testing.T) {
	template := template.Must(template.New("templates").Parse(""))

	controller := NewNewsletterController(template)

	w := httptest.NewRecorder()

	r := httptest.NewRequest(http.MethodGet, "/newsletter", nil)

	controller.Get(w, r)

	expected := http.StatusOK

	actual := w.Result().StatusCode

	if expected != actual {
		t.Errorf("\nExpected: %v\nActual: %v", expected, actual)
	}
}
