def imprimi(nota):
    print(f"imprimindo nota {nota.descricao}")


def salva(nota):
    print(f"salvando nota {nota.descricao}")


class Nota:

    def __init__(self, valor, descricao):
        self.valor = valor
        self.descricao = descricao


class FechaNotas:

    def __init__(self, notas, observadores=()):
        self.notas = notas
        self.observadores = observadores

    def fechar(self):
        for nota in self.notas:
            for observador in self.observadores:
                observador(nota)


if __name__ == '__main__':
    notas_a_fechar = (Nota(100, "descricao 1"), Nota(200, "descricao 2"))
    acoes_a_realizar = (imprimi, salva)
    FechaNotas(notas_a_fechar, acoes_a_realizar).fechar()
