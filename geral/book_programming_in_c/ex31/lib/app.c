#include <stdio.h>

int
factorial(int n)
{
  if (n == 0 || n == 1)
    return n;

  return n * factorial(n - 1);
}

int
main(int argc, char **argv)
{
  for(int i = 1; i <= 10; ++i) {
    printf("%i! = %i\n", i, factorial(i));
  }

  return 0;
}
