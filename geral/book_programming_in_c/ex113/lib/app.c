#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  char str1[] = "string compare test";
  char str2[] = "string";

  printf("%i\n", equals(str1, str2));
  printf("%i\n", equals(str1, str1));
  printf("%i\n", equals(str2, "string"));

  return EXIT_SUCCESS;
}
