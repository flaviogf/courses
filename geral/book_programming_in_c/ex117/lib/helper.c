#include <stdio.h>
#include <stdbool.h>
#include "helper.h"

void read_line(char buffer[])
{
  char character;
  int index = 0;

  do {
    character = getchar();
    buffer[index++] = character;
  } while(character != '\n');

  buffer[index - 1] = '\0';
}

bool alphabetic(const char c)
{
  return true;
}
