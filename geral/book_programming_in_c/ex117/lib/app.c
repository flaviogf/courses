#include <stdio.h>
#include <stdlib.h>
#include "helper.h"

int main(int argc, char **argv)
{
  printf("Type in your text.\n");
  printf("When you are done, press 'RETURN'.\n\n");

  char text[81];
  int total_words = 0;
  bool end_of_text = false;

  while(!end_of_text)
  {
    read_line(text);

    if(text[0] == '\0') {
      end_of_text = true;
    } else {
      total_words += count_words(text);
    }
  }

  printf("\nThere are %i words in the above text.\n", total_words);

  return EXIT_SUCCESS;
}
