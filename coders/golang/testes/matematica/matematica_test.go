package matematica

import "testing"

func TestMedia(t *testing.T) {
	esperado := 7.28

	resultado := Media(7.2, 9.9, 6.1, 5.9)

	if resultado != esperado {
		t.Errorf("Valor esperado %v, Valor encontrado: %v", esperado, resultado)
	}
}
