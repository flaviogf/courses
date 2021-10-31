CC = gcc
CFLAGS = -g

BUILD_DIR = bin
TARGET = bin/app
OBJS = lib/app.o

$(TARGET): $(OBJS)
	mkdir -p $(BUILD_DIR)
	$(CC) $(CFLAGS) -o $@ $<

%.o: %.c
	$(CC) -c $(CFLAGS) -o $@ $<

.PHONY:
clean:
	rm -rf $(BUILD_DIR) $(OBJS)
