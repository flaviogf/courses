package main

import (
	"fmt"
	"net"
	"sort"
	"time"
)

func worker(id int, jobs <-chan int, results chan<- int) {
	for j := range jobs {
		d := net.Dialer{Timeout: 5 * time.Second}
		conn, err := d.Dial("tcp", fmt.Sprintf("%s:%d", "scanme.nmap.org", j))

		if err != nil {
			results <- 0
			continue
		}

		defer conn.Close()
		results <- j
	}
}

func main() {
	numJobs := 1024
	jobs := make(chan int, numJobs)
	results := make(chan int, numJobs)
	ports := []int{}

	for w := 0; w < numJobs; w++ {
		go worker(w, jobs, results)
	}

	for i := 1; i <= numJobs; i++ {
		jobs <- i
	}

	for i := 0; i < numJobs; i++ {
		port := <-results

		if port != 0 {
			ports = append(ports, port)
		}
	}

	sort.Ints(ports)

	for _, port := range ports {
		fmt.Printf("%d open\n", port)
	}
}
