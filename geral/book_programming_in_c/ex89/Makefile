objects = foo.o bar.o all.o

all: $(objects)

foo.o: foo.c
bar.o: bar.c
all.o: all.c

all.c:
	echo 'int main() { return 0; }' > all.c

%.c:
	touch $(@)

clean:
	rm -rf *.c *.o all
