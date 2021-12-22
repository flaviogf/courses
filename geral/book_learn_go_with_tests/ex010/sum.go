package sum

func SumAll(values ...[]int) []int {
	result := make([]int, len(values))

	for i, value := range values {
		result[i] = Sum(value)
	}

	return result
}

func Sum(values []int) int {
	result := 0

	for _, value := range values {
		result += value
	}

	return result
}
