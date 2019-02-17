from datetime import date


class Nota:
    def __init__(self, valor, itens, descricao, data):
        self.valor = valor
        self.itens = itens
        self.descricao = descricao
        self.data = data


class ConstroiNota:
    def __init__(self):
        self.__valor = 0
        self.__itens = []
        self.__descricao = ""
        self.__data = date.today()

    def com_valor(self, valor):
        self.__valor = valor
        return self

    def com_itens(self, itens):
        self.__itens = itens
        return self

    def com_descricao(self, descricao):
        self.__descricao = descricao
        return self

    def com_data(self, data):
        self.__data = data
        return self

    def constroi(self):
        return Nota(
            valor=self.__valor,
            itens=self.__itens,
            descricao=self.__descricao,
            data=self.__data
        )


if __name__ == '__main__':
    nota = Nota(
        100,
        ['item1', 'item2'],
        "nenhuma",
        date.today()
    )
    nota2 = (ConstroiNota()
             .com_valor(500)
             .com_descricao("teste")
             .constroi())
    print(f"Nota {nota2.descricao} - Valor {nota2.valor}")
