FROM gcc as build
WORKDIR /www
COPY . .
RUN make

FROM gcc
WORKDIR /www
COPY --from=build /www/bin/app .
CMD ["./app"]
