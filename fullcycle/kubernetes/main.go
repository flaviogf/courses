package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"os"
)

func main() {
	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
		bytes, _ := os.ReadFile("/etc/config/cluster_endpoints")

		status := struct {
			AppName          string `json:"app_name"`
			ClusterEndpoints string `json:"cluster_endpoints"`
		}{
			AppName:          os.Getenv("APP_NAME"),
			ClusterEndpoints: string(bytes),
		}

		data, _ := json.Marshal(status)

		fmt.Fprintf(w, string(data))
	})

	http.ListenAndServe(":8080", nil)
}
