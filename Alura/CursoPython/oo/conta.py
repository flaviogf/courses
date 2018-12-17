class Conta:

    def __init__(self, numero, titular, saldo, limite):
        self.__numero = numero
        self.__titular = titular
        self.__saldo = saldo
        self.__limite = limite

    def __pode_sacar(self, valor_a_sacar):
        return self.__saldo >= valor_a_sacar

    def extrato(self):
        print("Saldo {}".format(self.__saldo))

    def deposita(self, valor):
        self.__saldo += valor

    def saca(self, valor):
        if self.__pode_sacar(valor):
            self.__saldo -= valor

    def tranfere(self, valor, outra):
        if self.__pode_sacar(valor):
            self.saca(valor)
            outra.deposita(valor)

    @property
    def saldo(self):
        return self.__saldo

    @staticmethod
    def codigo_banco():
        return "001"
