package registry

import (
	"encoding/json"
	"log"
	"net/http"
	"sync"
)

const ServerPort = ":3000"
const ServicesUrl = "http://localhost" + ServerPort + "/services"

type registry struct {
	registrations []Registration
	mutex         *sync.Mutex
}

func (r *registry) add(registration Registration) error {
	r.mutex.Lock()
	r.registrations = append(r.registrations, registration)
	r.mutex.Unlock()
	return nil
}

var reg = registry{registrations: []Registration{}, mutex: &sync.Mutex{}}

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
	default:
		rw.WriteHeader(http.StatusMethodNotAllowed)
	}
}
