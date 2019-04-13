from desconto import DescontoPorCincoItens, SemDesconto


class CalculadorDesconto:
    def calcula(self, orcamento):
        return DescontoPorCincoItens(SemDesconto()).calcula(orcamento)
