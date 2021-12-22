package sum

func SumAllTails(values ...[]int) []int {
	result := make([]int, len(values))

	for i, value := range values {
		if len(value) == 0 {
			result[i] = 0
		} else {
			result[i] = Sum(value[1:])
		}
	}

	return result
}

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
