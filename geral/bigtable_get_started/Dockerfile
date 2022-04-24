FROM golang:1.18 AS build
WORKDIR /www
COPY go.mod ./
COPY go.sum ./
RUN go mod download
COPY *.go ./
RUN GOOS=linux CGO_ENABLED=0 go build -o app main.go

FROM scratch
COPY --from=build /www/app ./
CMD ["./app"]
