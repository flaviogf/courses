package main

import (
	"image/color"
	"io"
	"os"
)

var palette = []color.Color{color.White, color.Black}

const (
	whiteIndex = 0
	blackIndex = 1
)

func main() {
	lissajous(os.Stdout)
}

func lissajous(out io.Writer) {
}
