FROM golang:1.15.3

WORKDIR /go/src

COPY . .

RUN GOOS=linux go build checkout.go

CMD [ "./checkout" ]

EXPOSE 8082
