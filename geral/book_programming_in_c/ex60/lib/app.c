#include <stdio.h>

int main()
{
  int n = 150;
  int i, j;

  int P[n];
  for(i = 0; i < n; i++)
    P[i] = 0;

  i = 2;
  j = 2;

  while(i < n) {
    while(i * j <= n) {
      P[i * j] = 1;
      ++j;
    }

    ++i;
    j = i;
  }

  for(i = 2; i < n; i++) {
    if(P[i] == 0)
      printf("%d ", i);
  }

  printf("\n");

  return 0;
}
