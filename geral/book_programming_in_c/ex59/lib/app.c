#include <stdio.h>

int main()
{
  int x = 0, y = 1;
  printf("%i %i ", x, y);

  for(int i = 0; i < 13; ++i) {
    int fibonacci = x + y;
    printf("%i ", fibonacci);
    x = y;
    y = fibonacci;
  }

  printf("\n");

  return 0;
}
