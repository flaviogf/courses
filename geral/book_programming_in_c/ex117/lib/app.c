#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  char input[81];
  read_line(input);
  printf("%s\n", input);
  return EXIT_SUCCESS;
}
