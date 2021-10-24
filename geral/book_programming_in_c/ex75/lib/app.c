#include <stdio.h>

int main()
{
  unsigned long int factorial(int n);

  for(int i = 0; i < 11; ++i)
    printf("%i! = %lu\n", i, factorial(i));

  return 0;
}

unsigned long int factorial(int n)
{
  if(n == 0)
    return 1;

  if(n == 1)
    return n;

  return n * factorial(n - 1);
}
