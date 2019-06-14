'''
P(A|B) = P(A,B) / P(B)
'''
from fractions import Fraction

probabilities = [(0, 0), (0, 1), (1, 0), (1, 1)]

n_s = len(probabilities)

event_a = {it for it in probabilities if it[0] == 0 and it[1] == 0}

event_b = {it for it in probabilities if it[0] == 0 or it[1] == 0}

p_b = Fraction(len(event_b), n_s)

p_a_intersect_b = Fraction(len(event_a.intersection(event_b)), n_s)

result = p_a_intersect_b / p_b

print(result)
