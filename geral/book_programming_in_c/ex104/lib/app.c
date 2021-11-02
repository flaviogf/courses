#include <stdio.h>
#include <stdlib.h>

struct time
{
  int hour;
  int minutes;
  int seconds;
};

int main(int argc, char **argv)
{
  printf("Enter the time (hh:mm:ss): ");
  struct time currentTime;
  scanf("%i:%i:%i", &currentTime.hour, &currentTime.minutes, &currentTime.seconds);

  printf("Updated times is %.2i:%.2i:%.2i.\n", currentTime.hour, currentTime.minutes, currentTime.seconds);

  return EXIT_SUCCESS;
}
