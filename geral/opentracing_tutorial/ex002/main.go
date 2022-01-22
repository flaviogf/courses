package main

import (
	"context"
	"fmt"
	"io"
	"log"
	"os"

	"go.opentelemetry.io/otel"
	"go.opentelemetry.io/otel/attribute"
	"go.opentelemetry.io/otel/exporters/jaeger"
	"go.opentelemetry.io/otel/exporters/stdout/stdouttrace"
	"go.opentelemetry.io/otel/sdk/resource"
	sdktrace "go.opentelemetry.io/otel/sdk/trace"
	semconv "go.opentelemetry.io/otel/semconv/v1.4.0"
	"go.opentelemetry.io/otel/trace"
)

var jaegerEndpoint string

func init() {
	jaegerEndpoint = os.Getenv("JAEGER_ENDPOINT")
}

func main() {
	tracer := initTracer()

	ctx, span := tracer.Start(context.Background(), "main")

	if len(os.Args[1:]) == 0 {
		span.SetAttributes(
			attribute.String("error.message", "did not enter a name"),
			attribute.Bool("error", true),
		)

		span.End()

		log.Fatal("you must enter a name")
	}

	span.AddEvent("Starting sayHello")

	sayHello(ctx, tracer, os.Stdout, os.Args[1])

	span.End()
}

func initTracer() trace.Tracer {
	stdoutExporter, err := stdouttrace.New(stdouttrace.WithPrettyPrint())

	if err != nil {
		log.Fatal(err)
	}

	jaegerExporter, err := jaeger.New(
		jaeger.WithCollectorEndpoint(jaeger.WithEndpoint(jaegerEndpoint)),
	)

	if err != nil {
		log.Fatal(err)
	}

	r := resource.NewWithAttributes(
		semconv.SchemaURL,
		semconv.ServiceNameKey.String("hello-world"),
	)

	tp := sdktrace.NewTracerProvider(
		sdktrace.WithSampler(sdktrace.AlwaysSample()),
		sdktrace.WithSyncer(stdoutExporter),
		sdktrace.WithSyncer(jaegerExporter),
		sdktrace.WithResource(r),
	)

	otel.SetTracerProvider(tp)

	return otel.Tracer("hello-world")
}

func sayHello(ctx context.Context, tracer trace.Tracer, w io.Writer, name string) {
	_, span := tracer.Start(ctx, "sayHello")
	defer span.End()

	message := fmt.Sprintf("Hello, %s\n", name)

	span.SetAttributes(
		attribute.String("sayHello.message", message),
		attribute.String("sayHello.name", name),
	)

	fmt.Fprint(w, message)
}
