#include <stdio.h>

int
main(int argc, char **argv)
{
  printf("What triangular number do you want? ");
  int number;
  scanf("%i", &number);

  int triangularNumber = 0;

  for (int n = 0; n <= number; ++n)
    triangularNumber += n;

  printf("Triangular number %i is %i\n", number, triangularNumber);

  return 0;
}
