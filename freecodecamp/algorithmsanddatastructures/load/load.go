package load

import (
	"bufio"
	"log"
	"os"
	"strconv"
)

func Values(filename string) []int {
	f, err := os.Open(filename)

	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	values := []int{}

	s := bufio.NewScanner(f)

	for s.Scan() {
		value, err := strconv.Atoi(s.Text())

		if err != nil {
			log.Fatal(err)
		}

		values = append(values, value)
	}

	return values
}
