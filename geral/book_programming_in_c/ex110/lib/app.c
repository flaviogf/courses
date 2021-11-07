#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  const char str1[] = { 'T', 'e', 's', 't' };
  const char str2[] = { 'w', 'o', 'r', 'k', 's', '.' };

  char result[11];
  concat(result, str1, 5, str2, 6);

  for(int i = 0; i < 11; ++i) {
    printf("%c", result[i]);
  }

  printf("\n");

  return EXIT_SUCCESS;
}
