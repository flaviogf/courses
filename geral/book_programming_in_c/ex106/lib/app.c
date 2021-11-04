#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  const struct month months[12] = {
    { 31, { 'J', 'a', 'n' } },
    { 29, { 'F', 'e', 'b' } },
    { 31, { 'M', 'a', 'r' } },
    { 30, { 'A', 'p', 'r' } },
    { 31, { 'M', 'a', 'y' } },
    { 30, { 'J', 'u', 'n' } },
    { 31, { 'J', 'u', 'l' } },
    { 31, { 'A', 'u', 'g' } },
    { 30, { 'S', 'e', 'p' } },
    { 31, { 'O', 'c', 't' } },
    { 30, { 'N', 'o', 'v' } },
    { 31, { 'D', 'e', 'c' } },
  };

  printf("Month Number of Days\n");

  for(int i = 0; i < 12; ++i) {
    printf(" %c%c%c %i\n", months[i].name[0], months[i].name[1], months[i].name[2], months[i].numberOfDays);
  }

  return EXIT_SUCCESS;
}
