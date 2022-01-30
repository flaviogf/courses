FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN CGO_ENABLED=0 GOOS=linux go build -o big_brother big_brother.go
