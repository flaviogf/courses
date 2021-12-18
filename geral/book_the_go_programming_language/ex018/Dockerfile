FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN go build cmd/boiling/main.go

FROM golang:1.17
WORKDIR /www
COPY --from=build /www/main ./
CMD ["./main"]
