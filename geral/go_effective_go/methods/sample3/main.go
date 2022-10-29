package main

import (
	"fmt"
	"net/http"
	"os"
)

func main() {
	http.HandleFunc("/args", http.HandlerFunc(ArgServer))
	http.ListenAndServe(":8080", nil)
}

func ArgServer(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintln(w, os.Args)
}
