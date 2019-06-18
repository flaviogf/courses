import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns

data = pd.read_csv('consumo_cerveja.csv', thousands=',')

data.columns = ['date',
                'average_temp',
                'min_temp',
                'max_temp',
                'mm',
                'weekend',
                'consumption']

ax = sns.distplot(data.consumption)

plt.show()
