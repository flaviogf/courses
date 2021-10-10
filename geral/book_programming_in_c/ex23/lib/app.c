#include <stdio.h>

int
main(int argc, char **argv)
{
  for(int i = 0; i < 5; ++i) {
    printf("What triangular number do you want? ");
    int number;
    scanf("%i", &number);

    int triangularNumber = 0;

    for(int j = 1; j <= number; ++j)
      triangularNumber += j;

    printf("Triangular number %u is %i\n\n", number, triangularNumber);
  }

  return 0;
}
