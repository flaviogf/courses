#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  char line[81];

  for(int i = 0; i < 3; ++i) {
    read_line(line);
    printf("%s\n\n", line);
  }

  return EXIT_SUCCESS;
}
