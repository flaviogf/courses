package main

import (
	"io"
	"log"
	"net/http"
	"os"
	"regexp"
)

func main() {
	http.HandleFunc("/", func(rw http.ResponseWriter, r *http.Request) {
		file, err := os.Open("public" + r.URL.Path)

		if err != nil {
			rw.WriteHeader(http.StatusNotFound)

			log.Println(err)

			return
		}

		regex, err := regexp.Compile(`.+\.(.+)`)

		if err != nil {
			rw.WriteHeader(http.StatusInternalServerError)

			log.Println(err)

			return
		}

		matches := regex.FindStringSubmatch(r.URL.Path)

		ext := matches[1]

		switch ext {
		case "css":
			rw.Header().Add("Content-Type", "text/css")
		case "js":
			rw.Header().Add("Content-Type", "text/js")
		case "html":
			rw.Header().Add("Content-Type", "text/html")
		default:
			rw.Header().Add("Content-Type", "text/plain")
		}

		io.Copy(rw, file)
	})

	err := http.ListenAndServe(":8080", nil)

	if err != nil {
		log.Fatal(err)
	}
}
