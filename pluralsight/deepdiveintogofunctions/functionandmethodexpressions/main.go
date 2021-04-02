package main

import "fmt"

type MathExpression = int

const (
	AddExpression MathExpression = iota
	SubExpression
)

func main() {
	expression := create(AddExpression)

	out(expression(10, 2))

	out(double(expression, 10, 2))

	expression = create(SubExpression)

	out(expression(10, 2))

	out(double(expression, 10, 2))
}

func create(expression MathExpression) func(float64, float64) float64 {
	switch expression {
	case AddExpression:
		return add
	case SubExpression:
		return sub
	default:
		panic("invalid expression")
	}
}

func add(x, y float64) float64 {
	return x + y
}

func sub(x, y float64) float64 {
	return x - y
}

func double(fn func(float64, float64) float64, x, y float64) float64 {
	return 2 * fn(x, y)
}

func out(result float64) {
	fmt.Printf("result: %.2f\n", result)
}
