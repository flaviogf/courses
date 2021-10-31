CC = gcc
CFLAGS = -g -I lib

BUILD_DIR = bin
TARGET = app
OBJS = lib/helper.o lib/app.o

$(BUILD_DIR)/$(TARGET): $(OBJS) 
	mkdir -p $(dir $@)
	$(CC) $(OBJS) $(CFLAGS) -o $@

%.o: %.c
	$(CC) -c $(CFLAGS) $< -o $@

.PHONY:
clean:
	rm -rf $(BUILD_DIR) $(OBJS)
