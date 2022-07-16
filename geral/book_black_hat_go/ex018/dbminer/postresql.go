package dbminer

type PostgreSQLMiner struct {
}

func NewPostgreSQLMiner() *PostgreSQLMiner {
	return &PostgreSQLMiner{}
}

func (pq *PostgreSQLMiner) GetSchema() (*Schema, error) {
	return &Schema{}, nil
}
