#include <stdio.h>

int calculateTriangularNumber(int n)
{
  int i, triangularNumber = 0;

  for(i = 1; i <= n; ++i)
    triangularNumber += i;

  return triangularNumber;
}

int main()
{
  for(int i = 10; i <= 50; i += 10)
    printf("Triangular number %i is %i\n", i, calculateTriangularNumber(i));

  return 0;
}
