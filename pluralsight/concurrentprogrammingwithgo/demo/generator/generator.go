package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

type Book struct {
	ID     int
	Title  string
	Author string
	Year   int
}

func main() {
	f, err := os.OpenFile("books.csv", os.O_APPEND|os.O_CREATE, 0644)

	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	w := bufio.NewWriter(f)

	fmt.Fprint(w, "id,title,author,year\n")

	for i := 0; i < 10; i++ {
		fmt.Fprintf(w, "%d,%s,%s,%d\n", i, "Title: "+strconv.Itoa(i), "Author: "+strconv.Itoa(i), 2000+i)
	}

	w.Flush()
}
