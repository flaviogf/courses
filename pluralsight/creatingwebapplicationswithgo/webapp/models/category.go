package models

type Category struct {
	ID          int
	Name        string
	Description string
}

func GetCategory(id int) (Category, error) {
	var category Category

	row := db.QueryRow("select id, name, description from category where id = $1", id)

	if err := row.Err(); err != nil {
		return category, err
	}

	err := row.Scan(&category.ID, &category.Name, &category.Description)

	if err != nil {
		return category, err
	}

	return category, nil
}

func GetCategories() ([]Category, error) {
	var categories []Category

	rows, err := db.Query("select id, name, description from category")

	if err != nil {
		return categories, err
	}

	for rows.Next() {
		var category Category

		err = rows.Scan(&category.ID, &category.Name, &category.Description)

		if err != nil {
			return categories, err
		}

		categories = append(categories, category)
	}

	return categories, nil
}
