#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  struct time t1 = { .hour = 3, .minutes = 45, .seconds = 15 };
  struct time t2 = { .hour = 9, .minutes = 44, .seconds = 3 };

  struct time result = elapsed_time(t1, t2);

  printf("Elapsed time: %.2i:%.2i:%.2i\n", result.hour, result.minutes, result.seconds);

  return EXIT_SUCCESS;
}
