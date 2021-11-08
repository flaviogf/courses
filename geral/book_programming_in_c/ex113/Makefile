CC = gcc
CFLAGS = -g

TARGET = bin/app
OBJS = lib/app.o

$(TARGET): $(OBJS)
	mkdir -p $(dir $@)
	$(CC) $(OBJS) $(CFLAGS) -o $@

%.o: %.c
	$(CC) -c $(CFLAGS) $< -o $@
