#include <iostream>
#include <climits>

using namespace std;

int main()
{
  int yearOfBirth = 1997;
  char gender = 'M';
  bool isOlderThan18 = true;
  float averageGrade = 4.5;
  double balance = 999999.99;

  cout << "MAX INT: " << INT_MAX << endl;
  cout << "MIN INT: " << INT_MIN << endl;
  cout << "Size of int is: " << sizeof(yearOfBirth) << endl;

  cout << "Size of unsigned int is: " << sizeof(unsigned int) << endl;
  cout << "MAX UNSIGNED INT: " << UINT_MAX << endl;
}
