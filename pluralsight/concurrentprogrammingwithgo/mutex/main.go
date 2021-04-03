package main

import (
	"fmt"
	"math/rand"
	"sync"
	"time"
)

var cache = make(map[int]*Book)

var rnd = rand.New(rand.NewSource(time.Now().UnixNano()))

func main() {
	wg := &sync.WaitGroup{}

	m := &sync.Mutex{}

	for i := 0; i < 10; i++ {
		id := rnd.Intn(10) + 1

		wg.Add(2)

		go func(id int, wg *sync.WaitGroup, m *sync.Mutex) {
			if book, ok := queryFromCache(id, m); ok {
				fmt.Println("from cache")

				fmt.Printf("Title:\t%q\nAuthor:\t%q\nYear:\t%d\n\n", book.Title, book.Author, book.ReleaseYear)
			}

			wg.Done()
		}(id, wg, m)

		go func(id int, wg *sync.WaitGroup, m *sync.Mutex) {
			if book, ok := queryFromDatabase(id, m); ok {
				fmt.Println("from database")

				fmt.Printf("Title:\t%q\nAuthor:\t%q\nYear:\t%d\n\n", book.Title, book.Author, book.ReleaseYear)
			}

			wg.Done()
		}(id, wg, m)
	}

	wg.Wait()
}

func queryFromCache(id int, m *sync.Mutex) (*Book, bool) {
	m.Lock()
	book, ok := cache[id]
	m.Unlock()
	return book, ok
}

func queryFromDatabase(id int, m *sync.Mutex) (*Book, bool) {
	time.Sleep(100 * time.Millisecond)

	book, ok := search(books, 0, len(books)-1, id)

	if ok {
		m.Lock()
		cache[id] = book
		m.Unlock()
	}

	return book, ok
}

func search(books []*Book, left, right, target int) (*Book, bool) {
	if right >= left {
		middle := (left + right) / 2

		if books[middle].ID == target {
			return books[middle], true
		}

		if books[middle].ID > target {
			return search(books, left, middle-1, target)
		}

		return search(books, middle+1, right, target)
	}

	return nil, false
}
