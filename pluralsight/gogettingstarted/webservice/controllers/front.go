package controllers

import (
	"encoding/json"
	"net/http"
)

func RegisterControllers() {
	uc := newUserController()

	http.Handle("/users", *uc)

	http.Handle("/users/", *uc)
}

func encodeAsJson(w http.ResponseWriter, v interface{}) {
	enc := json.NewEncoder(w)
	enc.Encode(v)
}
