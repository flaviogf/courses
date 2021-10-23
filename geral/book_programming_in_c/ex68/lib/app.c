#include <stdio.h>

int minimun(int values[10])
{
  int minValue = values[0];

  for(int i = 1; i < 10; ++i)
    if(values[i] < minValue)
      minValue = values[i];

  return minValue;
}

int main()
{
  int minimun(int values[10]);

  printf("Enter 10 scores\n");

  int scores[10];

  for(int i = 0; i < 10; ++i)
    scanf("%i", &scores[i]);

  int minScore = minimun(scores);
  printf("\nMinimum score is %i\n", minScore);

  return 0;
}
