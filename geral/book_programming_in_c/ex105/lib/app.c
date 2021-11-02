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
  struct time times[5] = {
    { 11, 59, 59 },
    { 12, 0, 0 },
    { 1, 29, 59 },
    { 23, 59, 59 },
    { 19, 12, 27 }
  };

  for(int i = 0; i < 5; ++i) {
    printf("Time is %.2i:%.2i:%.2i\n", times[i].hour, times[i].minutes, times[i].seconds);
  }

  return EXIT_SUCCESS;
}
