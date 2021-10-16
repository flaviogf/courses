#include <stdio.h>

int main()
{
  for(int i = 2; i <= 50; ++i) {
    _Bool isPrime = 1;

    for(int j = 2; j < i; ++j) {
      if(i % j == 0) {
        isPrime = 0;
        break;
      }
    }

    if(isPrime) {
      printf("%i ", i);
    }
  }

  printf("\n");

  return 0;
}
