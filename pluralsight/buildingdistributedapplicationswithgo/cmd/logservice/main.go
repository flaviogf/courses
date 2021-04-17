package main

import (
	"context"
	"fmt"
	stdlog "log"

	"github.com/flaviogf/gradebook/log"
	"github.com/flaviogf/gradebook/registry"
	"github.com/flaviogf/gradebook/service"
)

func main() {
	log.Run("./app.log")

	host, port := "localhost", "4000"

	serviceURL := fmt.Sprintf("http://%v:%v", host, port)

	registration := registry.Registration{
		ServiceName:      registry.LogService,
		ServiceURL:       serviceURL,
		RequiredServices: []registry.ServiceName{},
		ServiceUpdateURL: serviceURL + "/services",
	}

	ctx, err := service.Start(context.Background(), registration, host, port, log.RegisterHandlers)

	if err != nil {
		stdlog.Fatal(err)
	}

	<-ctx.Done()

	fmt.Println("Shutting down log service")
}
