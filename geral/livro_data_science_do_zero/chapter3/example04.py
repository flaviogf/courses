import matplotlib.pyplot as plt

variance = [1, 2, 4, 8, 16, 32, 64, 128, 256]

bias_squared = variance[::-1]

total_error = [x + y for x, y in zip(variance, bias_squared)]

xs = [i for i, _ in enumerate(variance)]

plt.plot(xs, variance, 'g-', label='variance')

plt.plot(xs, bias_squared, 'r-', label='bias')

plt.plot(xs, total_error, 'b:', label='total errors')

plt.legend(loc=9)

plt.xlabel('complexidade')

plt.title('Polarização e Variância')

plt.show()
