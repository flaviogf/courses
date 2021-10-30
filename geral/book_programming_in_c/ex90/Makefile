objects = foo.o bar.o all.o

all: $(objects)

$(objects): %.o: %.c

all.c:
	echo 'int main() { return 0; }' > all.c

%.c:
	touch $(@)

clean:
	rm -rf *.c *.o all
