#include <stdio.h>

int main()
{
  int fibonacci[15] = { 0, 1 };

  for(int i = 2; i < 15; ++i)
    fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];

  for(int i = 0; i < 15; ++i)
    printf("%i\n", fibonacci[i]);

  return 0;
}
