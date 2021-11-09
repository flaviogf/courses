#include <stdbool.h>
#include "helper.h"

int count_words(const char str[])
{
  bool looking_for_word = true;
  int word_count = 0;

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
  return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
}
