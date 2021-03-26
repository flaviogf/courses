package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"sort"
	"time"
)

type Values struct {
	Name     string  `json:"name"`
	TempMin  float32 `json:"tempMin"`
	TempMax  float32 `json:"tempMax"`
	Interval int     `json:"interval"`
	Values   []Value `json:"values"`
}

type Value struct {
	MessageID    int     `json:"messageId"`
	Temperature  float32 `json:"temperature"`
	EnqueuedTime string  `json:"enqueuedTime"`
}

type Reading struct {
	Hour       int
	Normal     float32
	OutOfRange float32
}

func main() {
	file, err := os.Open("data.json")

	if err != nil {
		log.Fatal(err)
	}

	defer file.Close()

	data, err := ioutil.ReadAll(file)

	if err != nil {
		log.Fatal(err)
	}

	var values Values

	json.Unmarshal(data, &values)

	groupedTemperature := make(map[int][]float32)

	for _, it := range values.Values {
		enqueuedTime, err := time.Parse("2006-01-02 15:04:05", it.EnqueuedTime)

		if err != nil {
			log.Fatal(err)
		}

		hour := enqueuedTime.Hour()

		groupedTemperature[hour] = append(groupedTemperature[hour], it.Temperature)
	}

	var readings []Reading

	for key, value := range groupedTemperature {
		var normal, outOfRange float32 = 0.0, 0.0

		for _, temperature := range value {
			if temperature >= values.TempMin && temperature <= values.TempMax {
				normal++
			} else {
				outOfRange++
			}
		}

		readings = append(readings, Reading{key, normal, outOfRange})
	}

	sort.Slice(readings, func(i, j int) bool {
		return readings[i].Hour < readings[j].Hour
	})

	fmt.Printf("Hour\tTotal\tNormal\tOut of Range\tPercent\n")

	for _, it := range readings {
		total := it.Normal + it.OutOfRange

		percent := it.OutOfRange / total * 100

		fmt.Printf("%v\t%v\t%v\t%5v\t%5.1f\n", it.Hour, total, it.Normal, it.OutOfRange, percent)
	}
}
