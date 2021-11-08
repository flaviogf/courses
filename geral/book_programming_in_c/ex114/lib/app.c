#include <stdio.h>
#include <stdlib.h>

int main(int argc, char **argv)
{
  printf("Enter text:\n");

  char str1[81], str2[81], str3[81];
  scanf("%s%s%s", str1, str2, str3);

  printf("\nstr1 = %s\nstr2 = %s\nstr3 = %s\n", str1, str2, str3);

  return EXIT_SUCCESS;
}
