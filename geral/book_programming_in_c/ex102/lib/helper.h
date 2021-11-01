#include <stdbool.h>

struct date
{
  int month;
  int day;
  int year;
};

int numberOfDays(struct date d);

bool isLeapYear(struct date d);
