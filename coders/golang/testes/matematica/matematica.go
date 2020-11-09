package matematica

import (
	"fmt"
	"strconv"
)

func Media(numeros ...float64) float64 {
	total := 0.0

	for _, numero := range numeros {
		total += numero
	}

	media, _ := strconv.ParseFloat(fmt.Sprintf("%.2f", total/float64(len(numeros))), 64)

	return media
}
