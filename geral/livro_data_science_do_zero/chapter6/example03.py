import random
from decimal import Decimal
from fractions import Fraction


def random_kid():
    return random.choice(['girl', 'boy'])


both_girls = 0
older_girls = 0
either_girls = 0

random.seed(0)

for _ in range(10000):
    younger = random_kid()
    older = random_kid()

    if older == 'girl':
        older_girls += 1
    if older == 'girl' and younger == 'girl':
        both_girls += 1
    if older == 'girl' or younger == 'girl':
        either_girls += 1

p_both_older = Fraction.from_decimal(round(Decimal(both_girls / older_girls),
                                           1))
p_both_either = Fraction.from_decimal(round(Decimal(both_girls / either_girls),
                                            1))

print(p_both_older)
print(p_both_either)
