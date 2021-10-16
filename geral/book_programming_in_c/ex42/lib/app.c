#include <stdio.h>
#include <libpq-fe.h>

int main()
{
  int version = PQlibVersion();
  printf("Version of libpq: %i\n", version);
  return 0;
}
