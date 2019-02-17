from decimal import Decimal, getcontext

print(Decimal(2.1) + Decimal(1.1))
getcontext().prec = 4
print(Decimal(2.2) + Decimal(1.1))

print(Decimal(9).sqrt())

print(5.0.is_integer())
print(dir(int))
print(dir(float))
print(dir(Decimal))
