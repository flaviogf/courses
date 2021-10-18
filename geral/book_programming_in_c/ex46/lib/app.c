#include <stdio.h>

int main()
{
  void accumulatorOperation(float *, float);
  void endOperation(float *, float);
  void sumOperation(float *, float);
  void subtractionOperation(float *, float);
  void multiplicationOperation(
  void printContentOf(float);

  float accumulator = 0;
  float number;
  char operator;

  do {
    printf("Begin Calculations\n");
    scanf("%f %c", &number, &operator);

    switch(operator) {
      case 'S':
        accumulatorOperation(&accumulator, number);
        break;
      case 'E':
        endOperation(&accumulator, number);
        break;
      case '+':
        sumOperation(&accumulator, number);
        break;
      case '-':
        subtractionOperation(&accumulator, number);
        break;
      case '*':
        accumulator *= number;
        printContentOf(accumulator);
        break;
      case '/':
        accumulator /= number;
        printContentOf(accumulator);
        break;
    }
  } while(operator != 'E');

  printf("End of program\n");

  return 0;
}

void accumulatorOperation(float *accumulator, float value) {
  void printContentOf(float);

  *accumulator = value;

  printContentOf(*accumulator);
}

void endOperation(float *accumulator, float value) {
  void printContentOf(float);

  printContentOf(*accumulator);
}

void sumOperation(float *accumulator, float value) {
  void printContentOf(float);

  *accumulator += value;

  printContentOf(*accumulator);
}

void subtractionOperation(float *accumulator, float value) {
  void printContentOf(float);

  *accumulator -= value;

  printContentOf(*accumulator);
}

void printContentOf(float accumulator)
{
  printf("= %.2f Contents of Accumulator\n", accumulator);
}
