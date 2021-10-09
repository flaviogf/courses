#include <stdio.h>

int
main(int argc, char **argv)
{
  printf("TABLE OF TRIANGULAR NUMBERS\n\n");
  printf("n SUM from 1 to n\n");
  printf("--- ---------------\n");

  int triangularNumber = 0;

  for(int n = 1; n <= 10; ++n) {
    triangularNumber += n;
    printf("%2i %i\n", n, triangularNumber);
  }

  return 0;
}
