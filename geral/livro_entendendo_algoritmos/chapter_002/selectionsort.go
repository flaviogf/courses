package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

type Song struct {
	Title string
	Times int
}

func (s Song) CompareTo(other Song) int {
	if s.Times == other.Times {
		return 0
	}

	if s.Times < other.Times {
		return -1
	}

	return 1
}

func main() {
	f, err := os.Open("songs.csv")

	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	s := bufio.NewScanner(f)

	songs := make([]Song, 0)

	s.Scan()

	for s.Scan() {
		row := strings.Split(s.Text(), ",")

		title := row[0]

		times, _ := strconv.Atoi(row[1])

		songs = append(songs, Song{title, times})
	}

	sortedList := selectionSort(songs)

	for _, song := range sortedList {
		fmt.Printf("%+v\n", song)
	}
}

func selectionSort(songs []Song) []Song {
	sortedList := make([]Song, len(songs))

	for i := range sortedList {
		lowest, index := min(songs)

		sortedList[i] = lowest

		songs = append(songs[:index], songs[index+1:]...)
	}

	return sortedList
}

func min(songs []Song) (Song, int) {
	result := songs[0]

	index := 0

	for i, song := range songs {
		if result.CompareTo(song) == -1 {
			result = song
			index = i
		}
	}

	return result, index
}
