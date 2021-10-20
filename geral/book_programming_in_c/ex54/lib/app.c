#include <stdio.h>

int main()
{
  int i, numFibs;
  printf("How many Fibonacci numbers do you want (between 1 and 75)? ");
  scanf("%i", &numFibs);

  if(numFibs < 1 || numFibs > 75) {
    printf("Bad number, sorry!\n");
    return -1;
  }

  unsigned long long int fibonacci[numFibs];

  fibonacci[0] = 0;
  fibonacci[1] = 1;

  for(i = 2; i < numFibs; ++i) {
    fibonacci[i] = fibonacci[i - 2] + fibonacci[i - 1];
  }

  for(i = 0; i < numFibs; ++i) {
    printf("%llu ", fibonacci[i]);
  }

  printf("\n");

  return 0;
}
