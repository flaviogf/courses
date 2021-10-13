#include <stdio.h>

int
main(int argc, char **argv)
{
  int numberOfGrades;
  printf("How many grades will you be entering? ");
  scanf("%i", &numberOfGrades);

  int gradeTotal = 0;
  int failureCount = 0;

  for(int i = 1; i <= numberOfGrades; ++i) {
    int grade;
    printf("Enter grade #%i: ", i);
    scanf("%i", &grade);

    gradeTotal += grade;

    if (grade < 65)
      ++failureCount;
  }

  float average = (float) gradeTotal / numberOfGrades;

  printf("\nGrade average = %.2f\n", average);
  printf("Number of failures = %i\n", failureCount);

  return 0;
}
