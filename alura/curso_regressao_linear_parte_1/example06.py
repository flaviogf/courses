import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

data = pd.read_csv('consumo_cerveja.csv', thousands=',')

data.columns = ['data',
                'avg_temp',
                'min_temp',
                'max_temp',
                'mm',
                'weekend',
                'consumption']

fig, ax = plt.subplots()

ax.figure.set_size_inches(12, 6)

sns.pairplot(data)

plt.show()
