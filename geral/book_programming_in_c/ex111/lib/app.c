#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  const char word1[] = { 'a', 's', 't', 'e', 'r', '\0' };
  const char word2[] = { 'a', 't', '\0' };
  const char word3[] = { 'a', 'w', 'e', '\0' };

  printf("%i %i %i\n", len(word1), len(word2), len(word3));

  return EXIT_SUCCESS;
}
