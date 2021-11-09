#include <stdbool.h>
#include "helper.h"

bool alphabetic(const char c)
{
  return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
}
