package grades

import (
	"fmt"
	"sync"
)

type Student struct {
	ID        int
	FirstName string
	LastName  string
	Grades    []Grade
}

func (s Student) Average() float32 {
	var result float32

	for _, grade := range s.Grades {
		result += grade.Score
	}

	return result / float32(len(s.Grades))
}

type Students []Student

func (ss Students) GetByID(id int) (Student, error) {
	for _, student := range ss {
		if student.ID == id {
			return student, nil
		}
	}

	return Student{}, fmt.Errorf("could not find the student")
}

var (
	students      Students
	studentsMutex sync.Mutex
)

type Grade struct {
	Title string
	Type  GradeType
	Score float32
}

type GradeType string

const (
	GradeTest     = GradeType("Test")
	GradeHomework = GradeType("Homework")
	GradeQuiz     = GradeType("Quiz")
)
