import matplotlib.pyplot as plt
import pandas as pd

data = pd.read_csv('consumo_cerveja.csv', thousands=',')

data.columns = ['date',
                'average_temp',
                'min_temp',
                'max_temp',
                'mm',
                'weekend',
                'consumption']


data.head()

data.consumption.describe().round(2)

fig, ax = plt.subplots()

data.consumption.plot()

ax.set_title('Consumo de Cerveja', fontsize=16)
ax.set_ylabel('# de Litros', fontsize=16)
ax.set_xlabel('# de Dias', fontsize=16)
ax.axis([-10, 370, 10, 50])

plt.show()
