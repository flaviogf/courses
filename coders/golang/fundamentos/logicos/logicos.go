package main

import "fmt"

func main() {
	tv50, tv32, sorvete := compras(true, true)

	fmt.Printf("Tv50: %t, TV32: %t, Sorvete: %t", tv50, tv32, sorvete)
}

func compras(trab1, trab2 bool) (bool, bool, bool) {
	comprarTv50 := trab1 && trab2
	comprarTv32 := trab1 != trab2
	comprarSorvete := trab1 || trab2

	return comprarTv50, comprarTv32, comprarSorvete
}
