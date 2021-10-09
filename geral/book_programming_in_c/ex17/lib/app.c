#include <math.h>
#include <stdio.h>

int main()
{
  printf("Enter the value of x: ");
  float x;
  scanf("%f", &x);
  float polynomial = 3 * pow(x, 3) - 5 * pow(x, 2) + 6;
  printf("The polynomial for x is: %.2f\n", polynomial);
  return 0;
}
