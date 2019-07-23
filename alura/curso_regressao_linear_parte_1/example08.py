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

ax = sns.jointplot(x='avg_temp', y='consumption', data=data, kind='reg')
ax.set_axis_labels('Average Temp.', 'Consumption', fontsize=18)

plt.show()
