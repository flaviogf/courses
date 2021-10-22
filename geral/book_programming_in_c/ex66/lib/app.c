#include <stdio.h>

float absoluteValue(float x)
{
  if(x < 0)
    x = -x;

  return x;
}

int main()
{
  float values[] = { 15.5, 20.0, -5.0 };

  for(int i = 0; i < 3; ++i)
    printf("%.2f ", absoluteValue(values[i]));

  printf("\n");

  return 0;
}
