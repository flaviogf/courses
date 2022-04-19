package server

import (
	"net/http"
	"time"

	"github.com/gorilla/mux"
)

func NewHTTPServer(addr string) *http.Server {
	httpsrv := newHTTPServer()

	r := mux.NewRouter()
	r.HandleFunc("/", httpsrv.handleProduce).Methods(http.MethodPost)
	r.HandleFunc("/", httpsrv.handleConsume).Methods(http.MethodGet)

	return &http.Server{
		Addr:              addr,
		Handler:           r,
		IdleTimeout:       5 * time.Second,
		ReadHeaderTimeout: 5 * time.Second,
	}
}

type httpServer struct {
	log *Log
}

func newHTTPServer() *httpServer {
	return &httpServer{
		log: NewLog(),
	}
}

func (h *httpServer) handleProduce(w http.ResponseWriter, r *http.Request) {
}

func (h *httpServer) handleConsume(w http.ResponseWriter, r *http.Request) {
}

type ProduceRequest struct {
	Record Record `json:"record"`
}

type ProduceResponse struct {
	Offset uint64 `json:"offset"`
}
