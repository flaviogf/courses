FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN go build cmd/server/main.go

FROM golang:1.17
WORKDIR /www
COPY --from=build /www/main ./
EXPOSE 8080 
CMD ["./main"]
