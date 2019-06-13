from collections import Counter

import matplotlib.pyplot as plt

num_friends = [100, 49, 41, 40, 25, 100, 49]

friends_count = Counter(num_friends)

xs = range(101)

ys = [friends_count[x] for x in xs]

plt.bar(xs, ys)

plt.axis([0, 101, 0, 25])

plt.title('Histograma de Contagem de Familiares')

plt.xlabel('# de familiares')

plt.ylabel('# de pessoas')


def mean(x): return sum(x) / len(x)


def median(x):
    size = len(x)
    sorted_x = sorted(x)
    midpoint = size // 2
    return sorted_x[midpoint] if size % 2 == 1 else (sorted_x[midpoint - 1] + sorted_x[midpoint]) / 2


def quartile(num_quartile, x):
    sorted_x = sorted(x)
    return sorted_x[int(num_quartile * len(sorted_x))]


def mode(x):
    c = Counter(x)
    import pdb
    pdb.set_trace()
    return [x for x, y in c.items() if y == max(c.values())]


if __name__ == '__main__':
    plt.show()
