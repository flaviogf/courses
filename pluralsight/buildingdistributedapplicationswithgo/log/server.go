package log

import (
	"io/ioutil"
	stdlog "log"
	"net/http"
	"os"
)

type fileLog string

var log *stdlog.Logger

func (f fileLog) Write(p []byte) (n int, err error) {
	file, err := os.OpenFile(string(f), os.O_CREATE|os.O_WRONLY|os.O_APPEND, 0600)

	if err != nil {
		return 0, err
	}

	defer file.Close()

	return file.Write(p)
}

func Run(destination string) {
	log = stdlog.New(fileLog(destination), "", stdlog.LstdFlags)
}

func RegisterHandlers() {
	http.HandleFunc("/log", func(rw http.ResponseWriter, r *http.Request) {
		bytes, err := ioutil.ReadAll(r.Body)

		if err != nil || len(bytes) == 0 {
			rw.WriteHeader(http.StatusBadRequest)

			return
		}

		write(string(bytes))
	})
}

func write(message string) {
	log.Printf("%v\n", message)
}
