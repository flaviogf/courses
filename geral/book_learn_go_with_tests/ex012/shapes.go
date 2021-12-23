package shapes

type Rectangle struct {
	Height float64
	Width  float64
}

func Perimeter(r Rectangle) float64 {
	return 2 * (r.Height + r.Width)
}

func Area(r Rectangle) float64 {
	return r.Height * r.Width
}
