#include <stdio.h>

float absoluteValue(float x)
{
  if(x < 0)
    x = -x;

  return x;
}

float squareRoot(float x)
{
  const float epsilon = .00001;
  float guess = 1.0;

  while(absoluteValue(guess * guess - x) >= epsilon)
    guess = (x / guess + guess) / 2.0;

  return guess;
}

int main()
{
  float numbers[] = { 2.0, 144.0, 17.5 };

  for(int i = 0; i < 3; ++i)
    printf("squareRoot (2.0) = %f\n", squareRoot(numbers[i]));

  return 0;
}
