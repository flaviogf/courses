#include <stdio.h>

int main()
{
  float squareRoot(float n, float epsilon);

  printf("squareRoot(%f) = (%f)\n", 2.0, squareRoot(2.0, .00001));
  printf("squareRoot(%f) = (%f)\n", 144.0, squareRoot(144.0, .00001));
  printf("squareRoot(%f) = (%f)\n", 17.5, squareRoot(17.5, .00001));

  return 0;
}

float squareRoot(float n, float epsilon)
{
  int absoluteValue(int n);

  float guess = 1.0;

  while(absoluteValue(guess * guess - n) >= epsilon)
    guess = (n / guess + guess) / 2.0;

  return guess;
}

int absoluteValue(int n)
{
  if(n < 0)
    n = -n;

  return n;
}
