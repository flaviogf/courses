#include "helper.h"

int difference_between(struct date d1, struct date d2)
{
  return n(d2) - n(d1);
}

int n(struct date d)
{
  return 1461 * f(d.year, d.month) / 4 + 153 * g(d.month) / 5 + d.day;
}

int f(int year, int month)
{
  if (month <= 2) {
    return year - 1;
  }

  return year;
}

int g(int month)
{
  if (month <= 2) {
    return month + 13;
  }

  return month + 1;
}
