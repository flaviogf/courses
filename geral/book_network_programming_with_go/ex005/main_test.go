package main

import (
	"context"
	"net"
	"sort"
	"testing"
	"time"
)

func TestDialContext(t *testing.T) {
	l, err := net.Listen("tcp", "127.0.0.1:")

	if err != nil {
		t.Fatal(err)
	}

	go func() {
		conn, err := l.Accept()

		if err != nil {
			conn.Close()
		}
	}()

	ctx, cancel := context.WithCancel(context.Background())

	worker := func(ctx context.Context, network, address string, jobs <-chan int, results chan<- int) {
		for j := range jobs {
			var d net.Dialer

			conn, err := d.DialContext(ctx, network, address)

			if err == nil {
				conn.Close()
			}

			select {
			case <-ctx.Done():
				results <- 0
			default:
				results <- j
			}
		}
	}

	numJobs := 10
	jobs := make(chan int, numJobs)
	results := make(chan int, numJobs)
	successfullyJobs := []int{}

	for w := 1; w <= 3; w++ {
		go worker(ctx, "tcp", l.Addr().String(), jobs, results)
	}

	for i := 1; i <= numJobs; i++ {
		jobs <- i
	}

	close(jobs)

	go func() {
		time.Sleep(500 * time.Microsecond)
		cancel()
	}()

	for i := 1; i <= numJobs; i++ {
		result := <-results

		if result != 0 {
			successfullyJobs = append(successfullyJobs, result)
		}
	}

	close(results)

	sort.Ints(successfullyJobs)

	for _, j := range successfullyJobs {
		t.Log(j)
	}
}
