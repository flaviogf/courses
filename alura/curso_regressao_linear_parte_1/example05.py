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

sns.pairplot(data, y_vars='consumption', x_vars=['avg_temp', 'min_temp', 'max_temp', 'weekend'])

plt.show()
