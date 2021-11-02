#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Enter today's date (mm dd yyyy): ");

  struct date thisDay;
  scanf("%i%i%i", &thisDay.month, &thisDay.day, &thisDay.year);

  struct date nextDay = updateDate(thisDay);
  printf("Tomorrow's date is %i/%i/%.2i.\n", nextDay.month, nextDay.day, nextDay.year % 100);

  return EXIT_SUCCESS;
}
