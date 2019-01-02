import shelve

from clipboard import copy, paste
from sys import argv


class Comandos:

    def __init__(self, comandos):
        self.__comandos = comandos

    def busca(self, nome_comando):
        return tuple(filter(lambda x: x.__str__() == nome_comando, self.__comandos))[0]


class SalvaChave:

    def __init__(self):
        self.__chave = None

    def inicia(self, chave):
        self.__chave = chave

    def executa(self):
        with shelve.open("chaves") as arquivo:
            arquivo[self.__chave] = paste()

    def __str__(self):
        return "salva"


class BuscaChave:

    def __init__(self):
        self.__chave = None

    def inicia(self, chave):
        self.__chave = chave

    def executa(self):
        with shelve.open("chaves") as arquivo:
            copy(arquivo[self.__chave])

    def __str__(self):
        return "busca"


class GerenciadorDeComando:

    def __init__(self, comandos):
        self.__comandos = comandos

    def executa(self, comando_escolhido, argumento):
        comando = self.__comandos.busca(comando_escolhido)
        comando.inicia(argumento)
        comando.executa()


class App:

    def __init__(self):
        self.__gerenciador = GerenciadorDeComando(Comandos([SalvaChave(), BuscaChave()]))

    def inicia(self):
        print("MULTICLIPBOARD START".center(50, "*"))
        while True:
            try:
                if len(argv) >= 2:
                    self.__gerenciador.executa(argv[1], argv[2])
                else:
                    self.__gerenciador.executa(*input("Escolha um comando: \n").split())
                break
            except TypeError:
                print("comando invalido")
            except IndexError:
                print("comando nao encontrado")


if __name__ == '__main__':
    App().inicia()
