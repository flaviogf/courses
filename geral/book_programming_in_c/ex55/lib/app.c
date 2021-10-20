#include <stdio.h>

int main()
{
  int numbers[10];

  for(int i = 0; i < 10; ++i)
    numbers[i] = 0;

  for(int i = 0; i < 10; ++i)
    printf("%i ", numbers[i]);

  printf("\n");

  return 0;
}
