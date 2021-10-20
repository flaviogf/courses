#include <stdio.h>

int main()
{
  int numbers[10];

  for(int i = 0; i < 10; ++i)
    numbers[i] = 0;

  int response;

  do
  {
    printf("Type in a number: ");
    scanf("%i", &response);

    if(response < 1 || response > 10)
      printf("Bad response: %i\n");
    else
      ++numbers[response - 1];
  } while(response != 999);

  for(int i = 0; i < 10; ++i)
    printf("%i: %i\n", i + 1, numbers[i]);

  return 0;
}
