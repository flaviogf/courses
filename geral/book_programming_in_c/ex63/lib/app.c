#include <stdio.h>

void printMessage()
{
  printf("Programming is fun.\n");
}

int main()
{
  for(int i = 0; i < 5; ++i)
    printMessage();

  return 0;
}
