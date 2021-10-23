#include <stdio.h>

int minimun(int values[], int numberOfElements)
{
  int minValue = values[0];

  for(int i = 0; i < numberOfElements; ++i)
    if(values[i] < minValue)
      minValue = values[i];

  return minValue;
}

int main()
{
  int minimun(int values[], int numberOfElements);

  int array1[5] = { 157, -28, -37, 26, 10 };
  int array2[7] = { 12, 45, 1, 10, 5, 3, 22 };

  printf("array1 minimun: %i\n", minimun(array1, 5));
  printf("array2 minimun: %i\n", minimun(array2, 7));

  return 0;
}
