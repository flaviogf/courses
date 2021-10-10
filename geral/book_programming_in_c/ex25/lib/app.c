#include <stdio.h>

int
main(int argc, char **argv)
{
  printf("Please type in two nonnegative integers.\n");
  int x, y;
  scanf("%i%i", &x, &y);

  while(y) {
    int temp = x % y;
    x = y;
    y = temp;
  }

  printf("Their greatest common divisor is %i\n", x);

  return 0;
}
