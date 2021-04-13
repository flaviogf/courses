package service

import (
	"context"
	"fmt"
	"log"
	"net/http"

	"github.com/flaviogf/gradebook/registry"
)

func Start(ctx context.Context, registration registry.Registration, host, port string, registerHandlers func()) (context.Context, error) {
	registerHandlers()

	ctx = startService(ctx, registration.ServiceName, host, port)

	err := registry.RegisterService(registration)

	if err != nil {
		return ctx, err
	}

	return ctx, nil
}

func startService(ctx context.Context, name registry.ServiceName, host, port string) context.Context {
	ctx, cancel := context.WithCancel(ctx)

	srv := http.Server{Addr: ":" + port}

	go func() {
		log.Println(srv.ListenAndServe())
		cancel()
	}()

	go func() {
		fmt.Printf("%v started. Press any key to stop\n", name)
		var s string
		fmt.Scanln(&s)
		srv.Shutdown(ctx)
		cancel()
	}()

	return ctx
}
