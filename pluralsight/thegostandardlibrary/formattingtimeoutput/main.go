package main

import (
	"fmt"
	"time"
)

func main() {
	now := time.Now()

	fmt.Println(now.Format("Mon Jan 2"))

	fmt.Println(now.Format(time.RFC3339))
}
