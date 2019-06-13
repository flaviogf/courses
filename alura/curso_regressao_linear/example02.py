import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns

data = pd.read_csv('consumo_cerveja.csv')

data.columns = ['date',
                'average_temp',
                'min_temp',
                'max_temp',
                'mm',
                'weekend',
                'consumption']

fig, ax = plt.subplots()

ax.set_title('Consumo de cerveja', fontsize=16)

sns.boxplot(data.consumption, orient='v', width=0.2)

plt.show()
