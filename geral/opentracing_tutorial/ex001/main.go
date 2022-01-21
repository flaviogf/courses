package main

import (
	"context"
	"fmt"
	"log"
	"os"

	"go.opentelemetry.io/otel"
	"go.opentelemetry.io/otel/exporters/jaeger"
	"go.opentelemetry.io/otel/sdk/resource"
	tracesdk "go.opentelemetry.io/otel/sdk/trace"
	semconv "go.opentelemetry.io/otel/semconv/v1.4.0"
	"go.opentelemetry.io/otel/trace"
)

var (
	jaegerEndpoint string
	serviceName    string
)

func init() {
	jaegerEndpoint = os.Getenv("JAEGER_ENDPOINT")
	serviceName = os.Getenv("SERVICE_NAME")
}

func main() {
	if len(os.Args[1:]) == 0 {
		log.Fatalln("you must specify a name")
	}

	exp, err := jaeger.New(
		jaeger.WithCollectorEndpoint(jaeger.WithEndpoint(jaegerEndpoint)),
	)

	if err != nil {
		log.Fatal(err)
	}

	res := resource.NewWithAttributes(
		semconv.SchemaURL,
		semconv.ServiceNameKey.String(serviceName),
	)

	tp := tracesdk.NewTracerProvider(
		tracesdk.WithSampler(tracesdk.AlwaysSample()),
		tracesdk.WithSyncer(exp),
		tracesdk.WithResource(res),
	)

	otel.SetTracerProvider(tp)

	ctx, span := tracer().Start(context.Background(), "main")
	defer span.End()

	sayHello(ctx, os.Args[1])
}

func sayHello(ctx context.Context, name string) {
	_, span := tracer().Start(ctx, "sayHello")
	defer span.End()

	fmt.Printf("Hello, %s\n", name)
}

func tracer() trace.Tracer {
	return otel.Tracer(serviceName)
}
