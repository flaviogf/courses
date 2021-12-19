package iteration

func Repeat(value string, times int) string {
	var result string

	for i := 0; i < times; i++ {
		result += value
	}

	return result
}
