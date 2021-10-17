#include <stdio.h>

int main()
{
  int divisionByZeroError();

  float x, y;
  printf("Type in two numbers to divide them: ");
  scanf("%f %f", &x, &y);

  if (y == 0) {
    return divisionByZeroError();
  }

  float result = x / y;

  printf("%.3f / %.3f = %.3f\n", x, y, result);

  return 0;
}

int divisionByZeroError()
{
  printf("Division by zero is not allowed\n");
  return -1;
}
