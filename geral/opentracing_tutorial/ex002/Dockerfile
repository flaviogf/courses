FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN CGO_ENABLED=0 GOOS=linux go build main.go

FROM scratch
COPY --from=build /www/main .
CMD ["./main"]
