class EstrategiaDeCorrida:
    def correr(self):
        pass


class CorrerRapido(EstrategiaDeCorrida):

    def correr(self):
        print("correndo rapido")


class CorrerDevagar(EstrategiaDeCorrida):

    def correr(self):
        print("correndo devagar")


class NaoCorre(EstrategiaDeCorrida):

    def correr(self):
        print("não corre")


class Felino:

    def __init__(self):
        self.estrategia_corrida = NaoCorre()

    def correr(self):
        self.estrategia_corrida.correr()


class Leao(Felino):

    def __init__(self):
        super().__init__()
        self.estrategia_corrida = CorrerDevagar()


class Leopardo(Felino):

    def __init__(self):
        super().__init__()
        self.estrategia_corrida = CorrerRapido()


class TigreDeBrinquedo(Felino):

    def __init__(self):
        super().__init__()


if __name__ == '__main__':
    leao = Leao()
    leao.correr()
    leao.estrategia_corrida = CorrerRapido()
    leao.correr()
    leao.estrategia_corrida = NaoCorre()
    leao.correr()
