package log

import (
	"bytes"
	"fmt"
	stdlog "log"
	"net/http"

	"github.com/flaviogf/gradebook/registry"
)

func SetClientLogger(serviceURL string, clienteService registry.ServiceName) {
	stdlog.SetPrefix(fmt.Sprintf("[%v] - ", clienteService))
	stdlog.SetFlags(0)
	stdlog.SetOutput(&clientLogger{url: serviceURL})
}

type clientLogger struct {
	url string
}

func (c *clientLogger) Write(data []byte) (int, error) {
	buffer := bytes.NewBuffer(data)

	resp, err := http.Post(c.url+"/log", "text/plain", buffer)

	if err != nil {
		return 0, err
	}

	if resp.StatusCode != http.StatusOK {
		return 0, fmt.Errorf("failed to send log message.")
	}

	return len(data), nil
}
