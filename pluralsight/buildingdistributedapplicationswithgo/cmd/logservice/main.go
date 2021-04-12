package main

import (
	"context"
	stdlog "log"

	"github.com/flaviogf/gradebook/log"
	"github.com/flaviogf/gradebook/service"
)

func main() {
	log.Run("./app.log")

	ctx, err := service.Start(context.Background(), "Log Service", "localhost", "4000", log.RegisterHandlers)

	if err != nil {
		stdlog.Fatal(err)
	}

	<-ctx.Done()
}
