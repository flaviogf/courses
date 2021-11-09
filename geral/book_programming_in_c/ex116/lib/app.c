#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  const char word1[] = "Well, here goes.";
  const char word2[] = "And here we go... again.";

  printf("%i\n", count_words(word1));
  printf("%i\n", count_words(word2));

  return EXIT_SUCCESS;
}
