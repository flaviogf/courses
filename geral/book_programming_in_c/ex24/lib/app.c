#include <stdio.h>

int
main(int argc, char **argv)
{
  int count = 1;

  while(count <= 5) {
    printf("%i\n", count);
    ++count;
  }

  return 0;
}
