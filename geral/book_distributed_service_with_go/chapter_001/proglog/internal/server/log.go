package server

import "sync"

type Log struct {
	mu      sync.Mutex
	records []Record
}

func NewLog() *Log {
	return &Log{}
}

func (c *Log) Append(record Record) (uint64, error) {
	c.mu.Lock()
	defer c.mu.Unlock()

	record.Offset = uint64(len(c.records))
	c.records = append(c.records, record)

	return record.Offset, nil
}

type Record struct {
	Offset uint64
}
