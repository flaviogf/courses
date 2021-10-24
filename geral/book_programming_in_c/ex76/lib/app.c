#include <stdio.h>

int main()
{
  int triangularNumber(int n);

  printf("%i\n", triangularNumber(10)); 
  printf("%i\n", triangularNumber(20)); 
  printf("%i\n", triangularNumber(50)); 

  return 0;
}

int triangularNumber(int n)
{
  int triangularNumber = 0;

  for(int i = 1; i <= n; ++i)
    triangularNumber += i;

  return triangularNumber;
}
