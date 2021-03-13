package main

import (
	"encoding/json"
	"log"
	"net/http"
)

func main() {
	http.HandleFunc("/", func(rw http.ResponseWriter, r *http.Request) {
		name := getQueryParameter(r.URL.Query()["name"])

		if len(name) == 0 {
			var response = map[string]string{
				"name": "Anonymous",
			}

			encoder := json.NewEncoder(rw)

			encoder.Encode(response)

			return
		}

		var response = map[string]string{
			"name": name,
		}

		encoder := json.NewEncoder(rw)

		encoder.Encode(response)
	})

	err := http.ListenAndServe(":3000", nil)

	if err != nil {
		log.Fatal(err)
	}
}

func getQueryParameter(parameters []string) string {
	if len(parameters) <= 0 {
		return ""
	}

	return parameters[0]
}
