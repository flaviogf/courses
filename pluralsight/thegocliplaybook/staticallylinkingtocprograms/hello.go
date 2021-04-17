package main

import "fmt"
import "C"

func main() {
}

//export Hello
func Hello() {
    fmt.Println("Hello Go")
}
