#include <stdio.h>

int gcd(int x, int y)
{
  int temp;

  while(y != 0) {
    temp = x % y;
    x = y;
    y = temp;
  }

  return x;
}

int main()
{
  int numbers[][3] = {
    { 150, 35 },
    { 1026, 405 },
    { 83, 240 }
  };

  for(int i = 0; i < 3; ++i) {
    printf("gcd(%i,%i) = %i\n", numbers[i][0], numbers[i][1], gcd(numbers[i][0], numbers[i][1]));
  }

  return 0;
}
