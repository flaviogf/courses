FROM golang:1.15.3

WORKDIR /go/src

COPY . .

RUN GOOS=linux go build product.go

CMD [ "./product" ]

EXPOSE 8080
