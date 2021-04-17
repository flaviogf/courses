package grades

func init() {
	students = []Student{
		{
			ID:        1,
			FirstName: "Frank",
			LastName:  "Castle",
			Grades: []Grade{
				{
					Title: "Exam I",
					Type:  GradeTest,
					Score: 5,
				},
				{
					Title: "Exam II",
					Type:  GradeTest,
					Score: 8,
				},
			},
		},
		{
			ID:        2,
			FirstName: "Peter",
			LastName:  "Parker",
			Grades: []Grade{
				{
					Title: "Exam I",
					Type:  GradeTest,
					Score: 10,
				},
				{
					Title: "Exam II",
					Type:  GradeTest,
					Score: 10,
				},
			},
		},
	}
}
