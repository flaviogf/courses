#include <stdio.h>

int main()
{
  printf("Enter the degree in fahrenheit:\n");
  int degrees_fahrenheit;
  scanf("%i", &degrees_fahrenheit);

  int degrees_celsius = (degrees_fahrenheit - 32) * 5 / 9;

  printf("%iF = %iC\n", degrees_fahrenheit, degrees_celsius);

  return 0;
}
