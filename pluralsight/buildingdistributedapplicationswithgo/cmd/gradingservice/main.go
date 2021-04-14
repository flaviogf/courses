package main

import (
	"context"
	"fmt"
	stdlog "log"

	"github.com/flaviogf/gradebook/grades"
	"github.com/flaviogf/gradebook/registry"
	"github.com/flaviogf/gradebook/service"
)

func main() {
	host, port := "localhost", "6000"

	serviceURL := fmt.Sprintf("http://%v:%v", host, port)

	registration := registry.Registration{
		ServiceName:      registry.GradingService,
		ServiceURL:       serviceURL,
		RequiredServices: []registry.ServiceName{registry.LogService},
		ServiceUpdateURL: serviceURL + "/services",
	}

	ctx, err := service.Start(context.Background(), registration, host, port, grades.RegisterHandlers)

	if err != nil {
		stdlog.Fatal(err)
	}

	<-ctx.Done()

	fmt.Println("Shuttind down grading service")
}
