#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  char str1[] = "string compare test";
  char str2[] = "string";

  printf("%i\n", equals(str1, str2));

  return EXIT_SUCCESS;
}
