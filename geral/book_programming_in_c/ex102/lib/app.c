#include <stdio.h>
#include <stdlib.h>
#include <helper.h>

int main(int argc, char **argv)
{
  struct date today, tomorrow;

  printf("Enter today's date (mm dd yyyy): ");
  scanf("%i%i%i", &today.month, &today.day, &today.year);

  if(today.day != numberOfDays(today)) {
    tomorrow.day = today.day + 1;
    tomorrow.month = today.month;
    tomorrow.year = today.year;
  } else if(today.month == 12) {
    tomorrow.day = 1;
    tomorrow.month = 1;
    tomorrow.year = today.year + 1;
  } else {
    tomorrow.day = 1;
    tomorrow.month = 1;
    tomorrow.year = today.year;
  }

  printf("Tomorrow's date is %i/%i/%.2i\n", tomorrow.month, tomorrow.day, tomorrow.year);

  return EXIT_SUCCESS;
}
