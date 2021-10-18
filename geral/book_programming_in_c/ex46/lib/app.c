#include <stdio.h>

void accumulatorOperation(float *, float);

void endOperation(float *, float);

void sumOperation(float *, float);

void subtractionOperation(float *, float);

void multiplicationOperation(float *, float);

void divisionOperation(float *, float);

void printContentOf(float);

int main()
{

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
        multiplicationOperation(&accumulator, number);
        break;
      case '/':
        divisionOperation(&accumulator, number);
        break;
    }
  } while(operator != 'E');

  printf("End of program\n");

  return 0;
}

void accumulatorOperation(float *accumulator, float value) {
  *accumulator = value;
  printContentOf(*accumulator);
}

void endOperation(float *accumulator, float value) {
  printContentOf(*accumulator);
}

void sumOperation(float *accumulator, float value) {
  *accumulator += value;
  printContentOf(*accumulator);
}

void subtractionOperation(float *accumulator, float value) {
  *accumulator -= value;
  printContentOf(*accumulator);
}

void multiplicationOperation(float *accumulator, float value) {
  *accumulator *= value;
  printContentOf(*accumulator);
}

void divisionOperation(float *accumulator, float value) {
  *accumulator /= value;
  printContentOf(*accumulator);
}

void printContentOf(float accumulator)
{
  printf("= %.2f Contents of Accumulator\n", accumulator);
}
