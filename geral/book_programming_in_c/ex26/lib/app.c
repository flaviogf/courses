#include <stdio.h>

int
main(int argc, char **argv)
{
  printf("Enter your number:\n");
  int number;
  scanf("%i", &number);

  while(number) {
    int rightDigit = number % 10;
    printf("%i", rightDigit);
    number = number / 10;
  }

  printf("\n");

  return 0;
}
