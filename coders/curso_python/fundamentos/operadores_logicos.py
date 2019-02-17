print(True or False)
print(True and False)
print(not True)
print(not 0)

salario = 1000.0
despesas = 500

saldo_positivo = salario > 0
despesa_controlada = salario - despesas >= 0.2 * salario
meta = saldo_positivo and despesa_controlada
print(meta)
