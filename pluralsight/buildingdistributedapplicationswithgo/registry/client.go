package registry

import (
	"bytes"
	"encoding/json"
	"fmt"
	"net/http"
)

func RegisterService(r Registration) error {
	buffer := &bytes.Buffer{}

	enc := json.NewEncoder(buffer)

	err := enc.Encode(r)

	if err != nil {
		return err
	}

	resp, err := http.Post(ServicesURL, "application/json", buffer)

	if err != nil {
		return err
	}

	if resp.StatusCode != http.StatusOK {
		return fmt.Errorf("could not register the new registration, status returned: %v", resp.StatusCode)
	}

	return nil
}

func ShutdownService(serviceURL string) error {
	buffer := bytes.NewBuffer([]byte(serviceURL))

	req, err := http.NewRequest(http.MethodDelete, ServicesURL, buffer)

	if err != nil {
		return err
	}

	resp, err := http.DefaultClient.Do(req)

	if err != nil {
		return err
	}

	if resp.StatusCode != 200 {
		return fmt.Errorf("could not shutdown the service, status returned: %v", resp.StatusCode)
	}

	return nil
}
