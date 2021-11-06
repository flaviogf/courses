#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Enter a date to discover the day of the week (mm/dd/yyyy): ");
  struct date today;
  scanf("%i/%i/%i", &today.month, &today.day, &today.year);

  char result[10];
  day_of_the_week(today, result);

  int index = 0;
  while(result[index] != '\0') {
    printf("%c", result[index]);
    ++index;
  }

  printf("\n");

  return EXIT_SUCCESS;
}
