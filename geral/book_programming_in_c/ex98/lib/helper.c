float absoluteValue(float x)
{
  if(x < 0) x = -x;

  return x;
}

float squareRoot(float x)
{
  float guess = 1.0;

  while(absoluteValue(((guess * guess / x) -1) * 100) != 0)
    guess = (x / guess + guess) / 2.0;

  return guess;
}
