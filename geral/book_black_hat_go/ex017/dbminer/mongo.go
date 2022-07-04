package dbminer

type MongoMiner struct {
}

func NewMongoMiner() *MongoMiner {
	return &MongoMiner{}
}

func (m *MongoMiner) GetSchema() (*Schema, error) {
	var result Schema

	return &result, nil
}
