#include <stdbool.h>
#include <stdio.h>

int main()
{
  for(int i = 2; i <= 50; ++i) {
    bool isPrime = true;

    for(int j = 2; j < i; ++j) {
      if(i % j == 0) {
        isPrime = false;
      }
    }

    if(isPrime) {
      printf("%i ", i);
    }
  }

  printf("\n");

  return 0;
}
