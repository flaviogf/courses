#include <iostream>

using namespace std;

int main()
{
  cout << "Enter your annual salary, please: ";
  float annualSalary;
  cin >> annualSalary;
  float monthlySalary = annualSalary / 12;
  cout << "Your annual salary is " << annualSalary << endl;
  cout << "Your monthly salary is " << monthlySalary << endl;
}
