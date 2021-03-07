FROM golang:1.16.0
WORKDIR /app
COPY . .
ENV GOOS linux
RUN go build
ENTRYPOINT [ "./myapplog" ]
