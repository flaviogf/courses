#include <stdio.h>

int main()
{
  float numbers[10] = { 10.0, 9.0, 8.0, 10.0, 8.0, 7.0, 6.0, 10.0, 10.0, 9.0 };

  float sum = 0.0;

  for(int i = 0; i < 10; ++i)
    sum += numbers[i];

  float average = sum / 10;

  printf("Average: %.2f\n", average);

  return 0;
}
