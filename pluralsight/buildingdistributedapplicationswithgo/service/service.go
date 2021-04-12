package service

import (
	"context"
	"fmt"
	"log"
	"net/http"
)

func Start(ctx context.Context, name, host, port string, registerHandlers func()) (context.Context, error) {
	registerHandlers()

	ctx = startService(ctx, name, host, port)

	return ctx, nil
}

func startService(ctx context.Context, name, host, port string) context.Context {
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
