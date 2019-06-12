from collections import Counter

import matplotlib.pyplot as plt

grades = [83, 95, 91, 87, 70, 0, 85, 82, 100, 67, 73, 77, 0]


def decile(g): return g // 10 * 10


histogram = Counter(decile(g) for g in grades)

plt.bar(histogram.keys(), histogram.values(), 8)
plt.axis([-5, 105, 0, 5])
plt.xticks([10 * i for i in range(11)])
plt.xlabel('Decil')
plt.ylabel('# de Alunos')
plt.title('Distribuição das Notas do Teste 1')
plt.show()
