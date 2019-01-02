class EstadoConta:

    def __init__(self, conta):
        self.conta = conta

    def saca(self, valor):
        self.conta.saldo -= valor

    def deposita(self, valor):
        self.conta.saldo += valor


class EstadoPositivo(EstadoConta):

    def saca(self, valor):
        super().saca(valor)
        if self.conta.saldo < 0:
            self.conta.estado = EstadoNegativo(self.conta)

    def __str__(self):
        return "positivo"


class EstadoNegativo(EstadoConta):

    def deposita(self, valor):
        super().deposita(valor)
        if self.conta.saldo >= 0:
            self.conta.estado = EstadoPositivo(self.conta)

    def __str__(self):
        return "negativo"


class Conta:

    def __init__(self):
        self.saldo = 0
        self.estado = EstadoPositivo(self)

    def deposita(self, valor):
        self.estado.deposita(valor)

    def saca(self, valor):
        self.estado.saca(valor)

    def extrato(self):
        print(f"estado da conta {self.estado} - saldo: {self.saldo}")


if __name__ == '__main__':
    conta1 = Conta()
    conta1.deposita(100)
    conta1.extrato()
    conta1.saca(100)
    conta1.extrato()
    conta1.saca(100)
    conta1.extrato()
    conta1.deposita(100)
    conta1.extrato()
