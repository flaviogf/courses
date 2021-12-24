package shapes

import "testing"

func TestArea(t *testing.T) {
	areaShapes := []struct {
		shape Shape
		want  float64
	}{
		{Rectangle{10.0, 10.0}, 100.0},
	}

	for _, tt := range areaShapes {
		got := tt.shape.Area()

		if got != tt.want {
			t.Errorf("got: %g, want: %g", got, tt.want)
		}
	}
}
