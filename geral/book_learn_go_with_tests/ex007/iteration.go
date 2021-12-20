package iteration

import "strings"

func Repeat(value string, times int) string {
	var builder strings.Builder

	for i := 0; i < times; i++ {
		builder.WriteString(value)
	}

	return builder.String()
}
