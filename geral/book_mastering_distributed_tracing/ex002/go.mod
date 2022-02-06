module github.com/courses/geral/book_mastering_distributed_tracing/ex002

go 1.17

require (
	github.com/gorilla/mux v1.8.0
	github.com/lib/pq v1.10.4
	go.opentelemetry.io/contrib/instrumentation/github.com/gorilla/mux/otelmux v0.28.0
	go.opentelemetry.io/otel v1.3.0
	go.opentelemetry.io/otel/exporters/stdout/stdouttrace v1.3.0
	go.opentelemetry.io/otel/sdk v1.3.0
)

require (
	github.com/felixge/httpsnoop v1.0.2 // indirect
	github.com/go-logr/logr v1.2.1 // indirect
	github.com/go-logr/stdr v1.2.0 // indirect
	go.opentelemetry.io/otel/trace v1.3.0 // indirect
	golang.org/x/sys v0.0.0-20210423185535-09eb48e85fd7 // indirect
)
