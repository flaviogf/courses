package controllers

import (
	"encoding/json"
	"net/http"
	"regexp"
	"strconv"

	"github.com/flaviogf/webservice/models"
)

type userController struct {
	userIDPattern *regexp.Regexp
}

func (uc userController) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	switch r.Method {
	case http.MethodGet:
		if r.URL.Path == "/users" {
			uc.getAll(w, r)
		} else {
			uc.get(w, r)
		}
	case http.MethodPost:
		uc.post(w, r)
	case http.MethodPut:
		uc.put(w, r)
	case http.MethodDelete:
		uc.delete(w, r)
	}
}

func newUserController() *userController {
	return &userController{userIDPattern: regexp.MustCompile(`^/users/(\d+)/?`)}
}

func (uc userController) getAll(w http.ResponseWriter, r *http.Request) {
	encodeAsJson(w, models.GetUsers())
}

func (uc userController) get(w http.ResponseWriter, r *http.Request) {
	matches := uc.userIDPattern.FindStringSubmatch(r.URL.Path)

	if len(matches) == 0 {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	id, err := strconv.Atoi(matches[1])

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	user, err := models.GetUserById(id)

	if err != nil {
		w.WriteHeader(http.StatusNotFound)

		return
	}

	encodeAsJson(w, user)
}

func (uc userController) post(w http.ResponseWriter, r *http.Request) {
	dec := json.NewDecoder(r.Body)

	user := models.User{}

	dec.Decode(&user)

	user, err := models.AddUser(user)

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	encodeAsJson(w, user)
}

func (uc userController) put(w http.ResponseWriter, r *http.Request) {
	matches := uc.userIDPattern.FindStringSubmatch(r.URL.Path)

	if len(matches) == 0 {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	id, err := strconv.Atoi(matches[1])

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	user, err := models.GetUserById(id)

	if err != nil {
		w.WriteHeader(http.StatusNotFound)

		return
	}

	dec := json.NewDecoder(r.Body)

	dec.Decode(&user)

	user, err = models.UpdateUser(user)

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	encodeAsJson(w, user)
}

func (uc userController) delete(w http.ResponseWriter, r *http.Request) {
	matches := uc.userIDPattern.FindStringSubmatch(r.URL.Path)

	if len(matches) == 0 {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	id, err := strconv.Atoi(matches[1])

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	err = models.RemoveUserById(id)

	if err != nil {
		w.WriteHeader(http.StatusInternalServerError)

		return
	}

	w.WriteHeader(http.StatusNoContent)
}
