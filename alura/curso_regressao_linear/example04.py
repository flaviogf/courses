import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns

data = pd.read_csv('consumo_cerveja.csv', thousands=',')

data.columns = ['data',
                'avg_temp',
                'min_temp',
                'max_temp',
                'mm',
                'weekend',
                'consumption']

ax = sns.boxplot(y='consumption', x='weekend', data=data, orient='v')

ax.set_title('Consumo de cerveja')

plt.show()
