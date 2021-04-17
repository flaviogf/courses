package grades

import (
	"encoding/json"
	"net/http"
	"regexp"
	"strconv"
)

func RegisterHandlers() {
	handler := new(studentsHandler)

	http.Handle("/students", handler)

	http.Handle("/students/", handler)
}

var (
	getAllPath   = regexp.MustCompile(`^/students$`)
	getOnePath   = regexp.MustCompile(`^/students/(\d+)$`)
	addGradePath = regexp.MustCompile(`^/students/(\d+)/grades$`)
)

type studentsHandler struct{}

func (sh studentsHandler) ServeHTTP(rw http.ResponseWriter, r *http.Request) {
	rw.Header().Set("Content-Type", "application/json")

	if getAllPath.MatchString(r.URL.Path) {
		sh.getAll(rw, r)
		return
	}

	if getOnePath.MatchString(r.URL.Path) {
		sh.getOne(rw, r)
		return
	}

	if addGradePath.MatchString(r.URL.Path) {
		sh.addGrade(rw, r)
		return
	}
}

func (sh studentsHandler) getAll(rw http.ResponseWriter, r *http.Request) {
	studentsMutex.Lock()

	defer studentsMutex.Unlock()

	enc := json.NewEncoder(rw)

	err := enc.Encode(students)

	if err != nil {
		rw.WriteHeader(http.StatusInternalServerError)

		return
	}
}

func (sh studentsHandler) getOne(rw http.ResponseWriter, r *http.Request) {
	studentsMutex.Lock()

	defer studentsMutex.Unlock()

	id, err := strconv.Atoi(getOnePath.FindStringSubmatch(r.URL.Path)[1])

	if err != nil {
		rw.WriteHeader(http.StatusNotFound)

		return
	}

	student, err := students.GetByID(id)

	if err != nil {
		rw.WriteHeader(http.StatusNotFound)

		return
	}

	enc := json.NewEncoder(rw)

	err = enc.Encode(student)

	if err != nil {
		rw.WriteHeader(http.StatusInternalServerError)

		return
	}
}

func (sh studentsHandler) addGrade(rw http.ResponseWriter, r *http.Request) {
	studentsMutex.Lock()

	defer studentsMutex.Unlock()

	id, err := strconv.Atoi(getOnePath.FindStringSubmatch(r.URL.Path)[1])

	if err != nil {
		rw.WriteHeader(http.StatusNotFound)

		return
	}

	student, err := students.GetByID(id)

	if err != nil {
		rw.WriteHeader(http.StatusNotFound)

		return
	}

	var grade Grade

	dec := json.NewDecoder(r.Body)

	err = dec.Decode(&grade)

	if err != nil {
		rw.WriteHeader(http.StatusInternalServerError)

		return
	}

	student.Grades = append(student.Grades, grade)

	rw.WriteHeader(http.StatusCreated)
}
