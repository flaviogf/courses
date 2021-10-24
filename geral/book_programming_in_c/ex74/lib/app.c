#include <stdio.h>

void autoStatic()
{
  int autoVar = 1;
  static int staticVar = 1;

  printf("automatic = %i, static = %i\n", autoVar, staticVar);

  ++autoVar;
  ++staticVar;
}

int main()
{
  for(int i = 0; i < 5; ++i)
    autoStatic();

  return 0;
}
