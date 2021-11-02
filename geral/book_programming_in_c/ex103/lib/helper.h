#include <stdbool.h>

struct date
{
  int month;
  int day;
  int year;
};

struct date updateDate(struct date d);

int numberOfDays(struct date d);

bool isLeapYear(struct date d);
