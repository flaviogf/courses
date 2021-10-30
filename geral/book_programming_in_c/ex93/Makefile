CC = gcc

TARGET = app
OBJS = app.o helper.o

$(TARGET): $(OBJS)

%.o: %.c
	$(CC) -c $(CFLAGS) $< -o $@

clean:
	rm -rf *.o app
