#include <stdio.h>

void printArray(int values[], int size)
{
  for(int i = 0; i < size; ++i)
    printf("%i ", values[i]);

  printf("\n");
}

void sort(int values[], int size)
{
  for(int i = 0; i < size - 1; ++i) {
    for(int j = i + 1; j < size; ++j) {
      if(values[i] > values[j]) {
        int temp = values[i];
        values[i] = values[j];
        values[j] = temp;
      }
    }
  }
}

int main()
{
  void printArray(int values[], int size);
  void sort(int values[], int size);

  int values[16] = { 34, -5, 6, 0, 12, 100, 56, 22, 44, -3, -9, 12, 17, 22, 6, 11 };

  printArray(values, 16);

  sort(values, 16);

  printArray(values, 16);

  return 0;
}
