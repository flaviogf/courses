package dbminer

import (
	"log"
	"regexp"
)

type DatabaseMiner interface {
	GetSchema() (*Schema, error)
}

type Schema struct {
	Databases []Database
}

type Database struct {
	Name   string
	Tables []Table
}

type Table struct {
	Name    string
	Columns []string
}

func Search(dm DatabaseMiner) error {
	s, err := dm.GetSchema()

	if err != nil {
		log.Fatalln(err)
	}

	re := getRegex()

	for _, database := range s.Databases {
		for _, table := range database.Tables {
			for _, column := range table.Columns {
				for _, r := range re {
					if r.MatchString(column) {
						log.Println(database)
						log.Printf("[+] HIT: %s\n", column)
					}
				}
			}
		}
	}

	return nil
}

func getRegex() []*regexp.Regexp {
	return []*regexp.Regexp{
		regexp.MustCompile("(?i)social"),
	}
}
