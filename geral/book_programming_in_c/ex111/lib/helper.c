#include "helper.h"

int len(const char value[])
{
  int i = 0;

  while(value[i] != '\0') ++i;

  return i;
}
