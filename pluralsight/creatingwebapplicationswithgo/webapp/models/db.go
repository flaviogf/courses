package models

import "database/sql"

var db *sql.DB

func SetDBInstance(instance *sql.DB) {
	db = instance
}
