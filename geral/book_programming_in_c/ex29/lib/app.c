#include <math.h>
#include <stdio.h>

int
main(int argc, char **argv)
{
  for(int n = 1; n <= 10; n++)
    printf("%2i\t%6.2f\n", n, pow(n, 2));


  return 0;
}
