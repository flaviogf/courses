#include <stdbool.h>
#include "helper.h"

struct date updateDate(struct date d)
{
  if(d.day != numberOfDays(d)) return (struct date) { .day = d.day + 1, .month = d.month, .year = d.year, };

  if(d.month == 12) return (struct date) { .day = 1, .month = 1, .year = d.year + 1, };

  return (struct date) { .day = 1, .month = d.month + 1, .year = d.year };
}

int numberOfDays(struct date d)
{
  const int daysPerMonth[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

  return isLeapYear(d) && d.month == 2 ? 29 : daysPerMonth[d.month - 1];
}

bool isLeapYear(struct date d)
{
  return (d.year % 4 == 0 && d.year % 100 != 0) || d.year % 400 == 0;
}
