#include <stdio.h>

int main()
{
  int sign(int);

  int number;
  printf("Please type in a number: ");
  scanf("%i", &number);

  printf("Sign = %i\n", sign(number));

  return 0;
}

int sign(int number)
{
  if (number < 0) return -1;
  else if (number == 0) return 0;
  else return 1;
}
