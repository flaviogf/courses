FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN CGO_ENABLED=0 GOOS=linux go build -o say_hello say_hello.go

FROM scratch
COPY --from=build /www/say_hello .
CMD ["./say_hello"]
