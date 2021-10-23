#include <stdio.h>

void multiplyBy2(float values[], int size)
{
  for(int i = 0; i < size; ++i)
    values[i] *= 2;
}

int main()
{
  void multiplyBy2(float values[], int size);

  float values[4] = { 1.2f, -3.7f, 6.2f, 8.55f };

  multiplyBy2(values, 4);

  for(int i = 0; i < 4; ++i)
    printf("%.2f ", values[i]);

  printf("\n");

  return 0;
}
