#include <stdio.h>
#include <stdlib.h>

int main(int argc, char **argv)
{
  struct date
  {
    int month;
    int day;
    int year;
  };

  struct date today;

  today.month = 9;
  today.day = 25;
  today.year = 2015;

  printf("Today's date is %i/%i/%.2i.\n", today.month, today.day, today.year % 100);

  return EXIT_SUCCESS;
}
