#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Enter the time (hh:mm:ss): ");
  struct time currentTime;
  scanf("%i:%i:%i", &currentTime.hour, &currentTime.minutes, &currentTime.seconds);

  struct time nextTime = timeUpdate(currentTime);

  printf("Updated times is %.2i:%.2i:%.2i.\n", nextTime.hour, nextTime.minutes, nextTime.seconds);

  return EXIT_SUCCESS;
}
