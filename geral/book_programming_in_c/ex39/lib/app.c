#include <stdio.h>

int main() {
  float x, y;
  char operator;
  printf("Type in your expression.\n");
  scanf("%f %c %f", &x, &operator, &y);

  if (operator == '+') {
    printf("%.2f\n", x + y);
  } else if (operator == '-') {
    printf("%.2f\n", x - y);
  } else if (operator == '*') {
    printf("%.2f\n", x * y);
  } else if (operator == '/') {
    printf("%.2f\n", x / y);
  }

  return 0;
}
