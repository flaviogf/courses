#include "helper.h"

void concat(char result[], const char str1[], int n1, const char str2[], int n2)
{
  int i = 0;

  for(int j = 0; j < n1; ++i, ++j) result[i] = str1[j];
  for(int j = 0; j < n2; ++i, ++j) result[i] = str2[j];
}
