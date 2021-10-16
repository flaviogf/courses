#include <stdio.h>

int main()
{
  float x, y;
  char operator;
  printf("Type in your expression.\n");
  scanf("%f %c %f", &x, &operator, &y);

  switch(operator) {
    case '+':
      printf("%.2f\n", x + y);
      break;
    case '-':
      printf("%.2f\n", x - y);
      break;
    case '*':
      printf("%.2f\n", x * y);
      break;
    case '/':
      printf("%.2f\n", x / y);
      break;
    default:
      printf("Oops, this is not a valid expression");
      break;
  }

  return 0;
}
