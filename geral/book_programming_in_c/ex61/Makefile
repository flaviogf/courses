all: run

run: build
	./bin/app

build:
	rm -rf ./bin
	mkdir -p ./bin
	cd ./lib && gcc app.c -o app
	mv ./lib/app ./bin/app
