#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  struct date d1 = { .month = 12, .day = 12, .year = 2020 };
  struct date d2 = { .month = 12, .day = 12, .year = 2021 };

  int result = difference_between(d1, d2);

  printf("The difference between the two dates is: %i\n", result);

  return EXIT_SUCCESS;
}
