class Desconto:
    def __init__(self, proximo_desconto=None):
        self._proximo_desconto = proximo_desconto


class DescontoPorCincoItens(Desconto):
    def calcula(self, orcamento):
        if len(orcamento.itens) >= 5:
            return orcamento.valor * 0.1

        return self._proximo_desconto.calcula(orcamento)


class SemDesconto(Desconto):
    def calcula(self, orcamento):
        return 0
