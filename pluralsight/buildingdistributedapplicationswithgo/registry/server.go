package registry

import (
	"bytes"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
	"sync"
)

const ServerPort = ":3000"
const ServicesURL = "http://localhost" + ServerPort + "/services"

type registry struct {
	registrations []Registration
	mutex         sync.RWMutex
}

func (r *registry) add(registration Registration) error {
	r.mutex.Lock()
	r.registrations = append(r.registrations, registration)
	r.mutex.Unlock()

	err := r.sendRequiredService(registration)

	if err != nil {
		return err
	}

	return nil
}

func (r *registry) sendRequiredService(registration Registration) error {
	r.mutex.RLock()

	defer r.mutex.RUnlock()

	var p patch

	for _, reg := range r.registrations {
		for _, serviceName := range registration.RequiredServices {
			if reg.ServiceName == serviceName {
				p.Added = append(p.Added, patchEntry{Name: reg.ServiceName, URL: reg.ServiceURL})
			}
		}
	}

	err := r.sendPatch(p, registration.ServiceUpdateURL)

	if err != nil {
		return err
	}

	return nil
}

func (r *registry) sendPatch(p patch, url string) error {
	buffer := &bytes.Buffer{}

	enc := json.NewEncoder(buffer)

	err := enc.Encode(p)

	if err != nil {
		return err
	}

	_, err = http.Post(url, "application/json", buffer)

	if err != nil {
		return err
	}

	return nil
}

func (r *registry) remove(serviceURL string) error {
	r.mutex.Lock()

	defer r.mutex.Unlock()

	for index, registration := range r.registrations {
		if serviceURL == registration.ServiceURL {
			r.registrations = append(r.registrations[:index], r.registrations[index+1:]...)

			return nil
		}
	}

	return fmt.Errorf("could not find the registration")
}

var reg = registry{registrations: []Registration{}, mutex: sync.RWMutex{}}

type RegistryService struct{}

func (rs RegistryService) ServeHTTP(rw http.ResponseWriter, r *http.Request) {
	log.Println("Request received")

	switch r.Method {
	case http.MethodPost:
		dec := json.NewDecoder(r.Body)

		var registration Registration

		err := dec.Decode(&registration)

		if err != nil {
			log.Println(err)

			rw.WriteHeader(http.StatusBadRequest)

			return
		}

		log.Printf("Adding service: %v with URL: %v\n", registration.ServiceName, registration.ServiceURL)

		err = reg.add(registration)

		if err != nil {
			log.Println(err)

			rw.WriteHeader(http.StatusInternalServerError)

			return
		}
	case http.MethodDelete:
		bytes, err := ioutil.ReadAll(r.Body)

		if err != nil {
			log.Println(err)

			rw.WriteHeader(http.StatusBadRequest)
		}

		serviceURL := string(bytes)

		log.Printf("Removing service with URL: %v\n", serviceURL)

		err = reg.remove(serviceURL)

		if err != nil {
			log.Println(err)

			rw.WriteHeader(http.StatusNotFound)

			return
		}
	default:
		rw.WriteHeader(http.StatusMethodNotAllowed)
	}
}
