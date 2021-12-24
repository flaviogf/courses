package shapes

import "testing"

func TestArea(t *testing.T) {
	areaTests := []struct {
		name    string
		shape   Shape
		hasArea float64
	}{
		{name: "Rectangle", shape: Rectangle{Height: 10.0, Width: 10.0}, hasArea: 100.0},
		{name: "Circle", shape: Circle{Radius: 10.0}, hasArea: 314.1592653589793},
		{name: "Triangle", shape: Triangle{Base: 12.0, Height: 6.0}, hasArea: 36.0},
	}

	for _, tt := range areaTests {
		got := tt.shape.Area()

		if got != tt.hasArea {
			t.Run(tt.name, func(t *testing.T) {
				t.Errorf("#%v, got: %g, want: %g", tt.shape, got, tt.hasArea)
			})
		}
	}
}
