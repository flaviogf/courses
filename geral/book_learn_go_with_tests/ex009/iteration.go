package iteration

func SumAll(values ...[]int) []int {
	sum := make([]int, len(values))

	for i, value := range values {
		sum[i] = Sum(value)
	}

	return sum
}

func Sum(values []int) int {
	sum := 0

	for _, value := range values {
		sum += value
	}

	return sum
}
