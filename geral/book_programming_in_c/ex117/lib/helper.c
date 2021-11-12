#include <stdio.h>
#include <stdbool.h>
#include "helper.h"

void read_line(char buffer[])
{
  char character;
  int index = 0;

  do {
    character = getchar();
    buffer[index++] = character;
  } while(character != '\n');

  buffer[index - 1] = '\0';
}

int count_words(const char str[])
{
  int word_count = 0;
  bool looking_for_word = true;

  for(int i = 0; str[i] != '\0'; ++i) {
    if(!alphabetic(str[i])) {
      looking_for_word = true;
      continue;
    }

    if(looking_for_word) {
      ++word_count;
      looking_for_word = false;
    }
  }

  return word_count;
}

bool alphabetic(const char c)
{
  return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
}
