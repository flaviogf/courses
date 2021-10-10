#include <stdio.h>

int
main(int argc, char **argv)
{
  printf("Enter your number:\n");
  int number;
  scanf("%i", &number);

  do {
    int rightDigit = number % 10;
    printf("%i", rightDigit);
    number /= 10;
  } while(number);

  printf("\n");

  return 0;
}
