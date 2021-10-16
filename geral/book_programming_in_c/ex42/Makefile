all: run

run: build
	./bin/app

build:
	mkdir -p bin
	cd ./lib && gcc -c -I$(shell pg_config --includedir) app.c
	cd ./lib && gcc -o app app.o -L$(shell pg_config --libdir) -lpq
	rm ./lib/app.o
	mv ./lib/app ./bin/app
