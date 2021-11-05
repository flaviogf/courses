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
  return month <= 2 ? year - 1 : year;
}

int g(int month)
{
  return month <= 2 ? month + 13 : month + 1;
}
