#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Enter the first time (hh:mm:ss): ");
  struct time t1;
  scanf("%i:%i:%i", &t1.hour, &t1.minutes, &t1.seconds);

  printf("Enter the second time (hh:mm:ss): ");
  struct time t2;
  scanf("%i:%i:%i", &t2.hour, &t2.minutes, &t2.seconds);

  struct time result = elapsed_time(t1, t2);

  printf("Elapsed time %.2i:%.2i:%.2i\n", result.hour, result.minutes, result.seconds);

  return EXIT_SUCCESS;
}
