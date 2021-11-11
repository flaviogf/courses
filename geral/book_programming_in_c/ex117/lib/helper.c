#include <stdio.h>
#include <stdbool.h>
#include "helper.h"

void read_line(char str[])
{
  char character;
  int index = 0;

  do {
    character = getchar();
    str[index++] = character;
  } while(character != '\n');

  str[index - 1] = '\0';
}

bool alphabetic(const char c)
{
  return true;
}
