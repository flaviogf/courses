package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
	"sync"
)

var cache = make(map[int]Book)

func main() {
	m := &sync.RWMutex{}

	if b, ok := queryFromDatabase(1, m); ok {
		fmt.Println(b)
	} else {
		fmt.Println("Book not found")
	}

	if b, ok := queryFromCache(1, m); ok {
		fmt.Println(b)
	} else {
		fmt.Println("Book not found")
	}
}

func queryFromCache(bookId int, m *sync.RWMutex) (Book, bool) {
	m.RLock()
	b, ok := cache[bookId]
	m.RUnlock()

	return b, ok
}

func queryFromDatabase(bookId int, m *sync.RWMutex) (Book, bool) {
	f, err := os.Open("books.csv")

	if err != nil {
		return Book{}, false
	}

	defer f.Close()

	s := bufio.NewScanner(f)

	for s.Scan() {
		r := s.Text()

		c := strings.Split(r, ",")

		id, _ := strconv.Atoi(c[0])

		if id == bookId {
			title := c[1]

			author := c[2]

			year, _ := strconv.Atoi(c[3])

			b := Book{ID: id, Title: title, Author: author, Year: year}

			m.Lock()
			cache[id] = b
			m.Unlock()

			return b, true
		}
	}

	return Book{}, false
}
