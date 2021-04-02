package main

import "fmt"

type semanticVersion struct {
	major, minor, patch int
}

func NewSemanticVersion(major, minor, patch int) *semanticVersion {
	return &semanticVersion{
		major: major,
		minor: minor,
		patch: patch,
	}
}

func (s *semanticVersion) String() string {
	return fmt.Sprintf("%d.%02d.%02d", s.major, s.minor, s.patch)
}

func (s *semanticVersion) IncrementMajor() {
	s.major++
}

func main() {
	version := NewSemanticVersion(1, 0, 0)

	fmt.Println(version.String())

	version.IncrementMajor()

	fmt.Println(version.String())
}
