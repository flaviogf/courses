from datetime import date


class Observer:

    def __init__(self, subject):
        self.__subject = subject

    def inscreve(self):
        self.__subject.adiciona_observador(self)

    def desinscreve(self):
        self.__subject.remove_observador(self)

    def atualiza(self, temparatura, horario):
        pass


class Subject:

    def __init__(self):
        self.observadores = []

    def adiciona_observador(self, observador):
        self.observadores.append(observador)

    def remove_observador(self, observador):
        self.observadores.remove(observador)

    def notifica_alteracao(self):
        pass


class EstacaoMetereologica(Subject):

    def __init__(self):
        super().__init__()
        self.__horario = date.today()
        self.__temperatura = 100

    def atualiza_dados_metereologicos(self, temperatura, horario):
        self.__temperatura = temperatura
        self.__horario = horario
        self.notifica_alteracao()

    def notifica_alteracao(self):
        for observador in self.observadores:
            observador.atualiza(self.__temperatura, self.__horario)


class Tela1(Observer):

    def atualiza(self, temperatura, horario):
        print("Tela 1")
        print(f"Temperatura {temperatura} - Horario - {horario.strftime('%d/%m/%y')}")


class Tela2(Observer):

    def atualiza(self, temperatura, horario):
        print("Tela 2")
        print(f"Temperatura {temperatura} - Horario - {horario.strftime('%d/%m/%y')}")


if __name__ == '__main__':
    estacao = EstacaoMetereologica()
    tela1 = Tela1(estacao)
    tela2 = Tela2(estacao)
    tela1.inscreve()
    tela2.inscreve()
    estacao.atualiza_dados_metereologicos(150, date.today())
    tela2.desinscreve()
    estacao.atualiza_dados_metereologicos(150, date.today())
    tela1.desinscreve()
    estacao.atualiza_dados_metereologicos(150, date.today())
