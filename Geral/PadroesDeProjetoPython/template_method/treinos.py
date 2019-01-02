class Treino:

    def __init__(self):
        self.__tempo = 100

    def treina(self):
        self.aquecimento(self.__tempo)
        self.coletivo()

    def aquecimento(self, tempo):
        pass

    def coletivo(self):
        pass


class TreinoInicioTemporada(Treino):

    def aquecimento(self, tempo):
        print(f"aquecimento leve tempo - {tempo}")

    def coletivo(self):
        print("treino com time junior")


class TreinoMeioTemporada(Treino):

    def aquecimento(self, tempo):
        print(f"aquecimento pessado - tempo {tempo}")

    def coletivo(self):
        print("treino com time reserva")


if __name__ == '__main__':
    treino = TreinoInicioTemporada()
    treino.treina()
    treino = TreinoMeioTemporada()
    treino.treina()
