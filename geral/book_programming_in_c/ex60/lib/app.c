#include <stdio.h>

int main()
{
  int numbers[50];

  for(int i = 1, j = 2; i < 50; ++i, ++j)
    numbers[i] = j;

  for(int i = 0; i < 50; ++i)
    printf("%i ", numbers[i]);

  printf("\n");

  return 0;
}
