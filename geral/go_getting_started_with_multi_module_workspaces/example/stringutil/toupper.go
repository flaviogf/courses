package stringutil

import "unicode"

func ToUpper(s string) string {
	r := []rune(s)

	for i := range s {
		r[i] = unicode.ToUpper(r[i])
	}

	return string(r)
}
