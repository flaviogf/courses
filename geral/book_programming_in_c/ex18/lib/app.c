#include <stdio.h>

int main()
{
  printf("Enter the values of i and j: ");
  int i, j;
  scanf("%i%i", &i, &j);

  int nextMultiple = i + j - i % j;

  printf("Next Multiple: %i\n", nextMultiple);

  return 0;
}
