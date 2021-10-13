#include <stdio.h>

int
main(int argc, char **argv)
{
  int numberToTest;
  printf("Enter your number to be tested: ");
  scanf("%i", &numberToTest);

  int remainder = numberToTest % 2;

  if (remainder == 0) {
    printf("The number is even.\n");
  } else {
    printf("The number is odd.\n");
  }

  return 0;
}
