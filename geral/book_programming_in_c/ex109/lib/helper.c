#include <stdio.h>
#include "helper.h"

const static char days_of_the_week[7][10] = {
  { 'S', 'u', 'n', 'd', 'a', 'y', '\0' },
  { 'M', 'o', 'n', 'd', 'a', 'y', '\0' },
  { 'T', 'u', 'e', 's', 'd', 'a', 'y', '\0' },
  { 'W', 'e', 'd', 'n', 'e', 's', 'd', 'a', 'y', '\0' },
  { 'T', 'h', 'u', 'r', 's', 'd', 'a', 'y', '\0' },
  { 'F', 'r', 'i', 'd', 'a', 'y', '\0' },
  { 'S', 'a', 't', 'u', 'r', 'd', 'a', 'y', '\0' }
};

void day_of_the_week(struct date d, char * result)
{
  int i = index_day_of_the_week(d);

  for(int j = 0; j < 10; ++j) {
    result[j] = days_of_the_week[i][j];
  }
}

static int index_day_of_the_week(struct date d)
{
  return (n(d) - 621049) % 7;
}

static int n(struct date d)
{
  return 1461 * f(d.year, d.month) / 4 + 153 * g(d.month) / 5 + d.day;
}

static int f(int year, int month)
{
  return month <= 2 ? year - 1 : year;
}

static int g(int month)
{
  return month <= 2 ? month + 13 : month + 1;
}
