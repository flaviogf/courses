thing_wrong := *.o
thing_right := $(wildcard *.o)

all: one two three four

one: $(thing_wrong)
	ls -la $?

two: *.o
	ls -la $?

three: $(thing_right)
	ls -la $?

four: $(wildcard *.o)
	ls -la $?
