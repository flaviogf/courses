int xToTheN(int x, int n)
{
  int result = x;

  for(int i = 1; i < n; i++)
    result *= x;

  return result;
}
