FROM gcc AS builder
WORKDIR /www
COPY . .
RUN make

FROM gcc
WORKDIR /www
COPY --from=builder /www/bin/app .
CMD ["./app"]
