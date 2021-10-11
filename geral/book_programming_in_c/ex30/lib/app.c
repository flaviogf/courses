#include <stdio.h>

int
main(int argc, char **argv)
{
  for(int i = 5; i <= 50; ++i) {
    int triangularNumber = i * (i + 1) / 2;
    printf("%i\n", triangularNumber);
  }

  printf("\n");

  return 0;
}
