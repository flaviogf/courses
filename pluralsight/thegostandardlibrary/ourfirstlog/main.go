package main

import (
	"log"
	"os"
)

type LogLevel int

const (
	INFO LogLevel = iota
	WARNING
	ERROR
	FATAL
)

func main() {
	file, err := os.OpenFile("ourfirstlog.log", os.O_CREATE|os.O_APPEND|os.O_WRONLY, 0666)

	if err != nil {
		writeLog(FATAL, err.Error())
	}

	log.SetOutput(file)

	writeLog(INFO, "This is an information message")

	writeLog(WARNING, "This is a waning message")

	writeLog(ERROR, "This is an error message")

	writeLog(FATAL, "This is a fatal message")

	writeLog(INFO, "This message will never be written")
}

func writeLog(logLevel LogLevel, message string) {
	funcs := map[LogLevel]func(string){
		INFO: func(s string) {
			logger := log.New(log.Writer(), "INFO: ", log.LstdFlags|log.Llongfile)
			logger.Println(message)
		},
		WARNING: func(s string) {
			logger := log.New(log.Writer(), "WARNING: ", log.LstdFlags|log.Llongfile)
			logger.Println(message)
		},
		ERROR: func(s string) {
			logger := log.New(log.Writer(), "ERROR: ", log.LstdFlags|log.Llongfile)
			logger.Println(message)
		},
		FATAL: func(s string) {
			logger := log.New(log.Writer(), "FATAL: ", log.LstdFlags|log.Llongfile)
			logger.Fatal(message)
		},
	}

	funcs[logLevel](message)
}
