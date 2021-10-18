#include <stdio.h>

int main()
{
  int arrayValues[10] = { 0, 1, 4, 9, 16 };

  for(int i = 5; i < 10; ++i)
    arrayValues[i] = i * i;

  for(int i = 0; i < 10; ++i)
    printf("arrayValues[%i] = %i\n", i, arrayValues[i]);

  return 0;
}
