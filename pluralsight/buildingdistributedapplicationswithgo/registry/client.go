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

	resp, err := http.Post(ServicesUrl, "application/json", buffer)

	if err != nil {
		return err
	}

	if resp.StatusCode != http.StatusOK {
		return fmt.Errorf("could not register the new registration, status returned: %v", resp.StatusCode)
	}

	return nil
}
