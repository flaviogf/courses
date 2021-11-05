#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Enter the first date (mm/dd/yyyy): ");
  struct date d1;
  scanf("%i/%i/%i", &d1.month, &d1.day, &d1.year);

  printf("Enter the second date (mm/dd/yyyy): ");
  struct date d2;
  scanf("%i/%i/%i", &d2.month, &d2.day, &d2.year);

  int result = difference_between(d1, d2);

  printf("The difference between the two dates is: %i\n", result);

  return EXIT_SUCCESS;
}
