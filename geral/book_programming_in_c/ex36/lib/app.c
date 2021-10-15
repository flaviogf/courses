#include <stdbool.h>
#include <stdio.h>

int main()
{
  bool isLeapYear(int);

  int year = 2000;
  printf("Enter the year to be tested: ");
  scanf("%i", &year);

  if (isLeapYear(year)) {
    printf("It's a leap year.\n");
  } else {
    printf("Nope, it's not a leap year.\n");
  }

  return 0;
}

bool isLeapYear(int year)
{
  return ((year % 4 == 0 && year % 100 == 0) || year % 400 == 0);
}
