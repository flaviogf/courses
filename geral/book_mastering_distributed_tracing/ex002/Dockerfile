FROM golang:1.17 AS build
WORKDIR /www
COPY . ./
RUN CGO_ENABLED=0 GOOS=linux go build -o say_hello say_hello.go
RUN CGO_ENABLED=0 GOOS=linux go build -o big_brother big_brother.go
RUN CGO_ENABLED=0 GOOS=linux go build -o formatter formatter.go

FROM scratch
COPY --from=build /www/say_hello .
COPY --from=build /www/big_brother .
COPY --from=build /www/formatter .
EXPOSE 80
