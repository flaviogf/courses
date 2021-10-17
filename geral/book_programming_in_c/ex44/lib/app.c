#include <stdbool.h>
#include <stdio.h>

int main()
{
  bool isDivisibleBy(int, int);
  int x, y;
  printf("Type in two numbers to discover if the first one is divisible by the second one: ");
  scanf("%i %i", &x, &y);

  isDivisibleBy(x, y) ? printf("It is divisible!\n") : printf("It is not divisible!\n");

  return 0;
}

bool isDivisibleBy(int x, int y)
{
  return x % y == 0;
}
