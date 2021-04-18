#include "stdio.h"
#include "limits.h"

int main() {
  short int var1 = SHRT_MIN;
  short int var2 = SHRT_MAX;

  printf("short int range goes from %d to %d\n", var1, var2);

  int var3 = INT_MIN;
  int var4 = INT_MAX;

  printf("int range goes from %d to %d\n", var3, var4);

  long int var5 = LONG_MIN;
  long int var6 = LONG_MAX;

  printf("long int range goes from %ld to %ld\n", var5, var6);

  printf("size of short int is equal to %ld\n", sizeof(short int));

  printf("size of int is equal to %ld\n", sizeof(int));

  printf("size of long int is equal to %ld\n", sizeof(long int));

  return 0;
}
