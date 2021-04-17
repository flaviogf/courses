package registry

import (
	"bytes"
	"encoding/json"
	"fmt"
	"math/rand"
	"net/http"
	"net/url"
	"sync"
)

func RegisterService(r Registration) error {
	serviceUpdateURL, err := url.Parse(r.ServiceUpdateURL)

	if err != nil {
		return err
	}

	http.Handle(serviceUpdateURL.Path, &serviceUpdateHandler{})

	buffer := &bytes.Buffer{}

	enc := json.NewEncoder(buffer)

	err = enc.Encode(r)

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

type providers struct {
	services map[ServiceName][]string
	mutex    sync.RWMutex
}

func (p *providers) Update(pat patch) {
	p.mutex.Lock()

	defer p.mutex.Unlock()

	for _, patchEntry := range pat.Added {
		if _, ok := p.services[patchEntry.Name]; !ok {
			p.services[patchEntry.Name] = make([]string, 0)
		}

		p.services[patchEntry.Name] = append(p.services[patchEntry.Name], patchEntry.URL)
	}

	for _, patchEntry := range pat.Removed {
		if providerURLs, ok := p.services[patchEntry.Name]; ok {
			for i, providerURL := range providerURLs {
				if providerURL == patchEntry.URL {
					p.services[patchEntry.Name] = append(p.services[patchEntry.Name][:i], p.services[patchEntry.Name][i+1:]...)
				}
			}
		}
	}
}

func GetProvider(name ServiceName) (string, error) {
	return prov.get(name)
}

func (p *providers) get(name ServiceName) (string, error) {
	providers, ok := p.services[name]

	if !ok {
		return "", fmt.Errorf("no providers availables for service: %v", name)
	}

	id := rand.Intn(len(providers))

	return providers[id], nil
}

var prov = providers{
	services: make(map[ServiceName][]string),
	mutex:    sync.RWMutex{},
}

type serviceUpdateHandler struct{}

func (s *serviceUpdateHandler) ServeHTTP(rw http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		rw.WriteHeader(http.StatusMethodNotAllowed)

		return
	}

	dec := json.NewDecoder(r.Body)

	var p patch

	err := dec.Decode(&p)

	if err != nil {
		rw.WriteHeader(http.StatusBadRequest)

		return
	}

	fmt.Printf("Update received: %+v\n", p)

	prov.Update(p)
}
