#include <stdio.h>

int main()
{
  void scalarMultiply(int nRows, int nCols, int matrix[nRows][nCols], int scalar);
  void displayMatrix(int nRows, int nCols, int matrix[nRows][nCols]);

  int sampleMatrix[3][5] = {
    { 7, 16, 55, 13, 12 },
    { 12, 10, 52, 0, 7 },
    { -2, 1, 2, 4, 9 }
  };

  printf("Original matrix:\n");
  displayMatrix(3, 5, sampleMatrix);

  scalarMultiply(3, 5, sampleMatrix, 2);
  printf("\nMultiplied by 2:\n");
  displayMatrix(3, 5, sampleMatrix);

  scalarMultiply(3, 5, sampleMatrix, -1);
  printf("\nThen multiple by -1:\n");
  displayMatrix(3, 5, sampleMatrix);

  return 0;
}

void scalarMultiply(int nRows, int nCols, int matrix[nRows][nCols], int scalar)
{
  for(int row = 0; row < nRows; ++row)
    for(int column = 0; column < nCols; ++column)
      matrix[row][column] *= scalar;
}

void displayMatrix(int nRows, int nCols, int matrix[nRows][nCols])
{
  for(int row = 0; row < nRows; ++row)
    for(int column = 0; column < nCols; ++column)
      printf("%5i ", matrix[row][column]);

  printf("\n");
}
